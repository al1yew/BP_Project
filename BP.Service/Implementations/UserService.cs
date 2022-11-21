using AutoMapper;
using BP.Core;
using BP.Core.Entities;
using BP.Service.DTOs.UserDTOs;
using BP.Service.Exceptions;
using BP.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;


        public UserService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<List<UserListDTO>> GetAllAsync(string username)
        {
            return _mapper.Map<List<UserListDTO>>(await _unitOfWork.AppUserRepository.GetAllByExAsync(x => x.UserName != username && x.NormalizedUserName != "SUPERADMIN"));
        }

        public async Task<UserGetDTO> GetById(string id)
        {
            AppUser appUser = await _unitOfWork.AppUserRepository.GetAsync(x => x.Id == id);

            if (appUser == null)
                throw new NotFoundException($"User cannot be found by id = {id}");

            return _mapper.Map<UserGetDTO>(appUser);
        }

        public async Task CreateAsync(UserPostDTO userPostDTO)
        {
            AppUser appUser = _mapper.Map<AppUser>(userPostDTO);

            IdentityResult result = await _userManager.CreateAsync(appUser, userPostDTO.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    throw new BadRequestException(error.Description);
                }
            }

            result = await _userManager.AddToRoleAsync(appUser, "Admin");
        }

        public async Task UpdateAsync(string id, UserPutDTO userPutDTO)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            if (id != userPutDTO.Id)
                throw new BadRequestException($"Id's are not the same!");

            AppUser dbAppUser = await _unitOfWork.AppUserRepository.GetAsync(x => x.Id == id);

            if (dbAppUser == null)
                throw new NotFoundException($"User Cannot be found By id = {id}");

            dbAppUser.Name = userPutDTO.Name;
            dbAppUser.Surname = userPutDTO.Surname;
            dbAppUser.Email = userPutDTO.Email;
            dbAppUser.PhoneNumber = userPutDTO.PhoneNumber;
            dbAppUser.UserName = userPutDTO.UserName;

            IdentityResult result = await _userManager.UpdateAsync(dbAppUser);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    throw new BadRequestException(error.Description);
                }
            }
        }

        public async Task<List<UserListDTO>> DeleteAsync(string id, string username)
        {
            if (id == null)
                throw new BadRequestException($"Id is null!");

            AppUser dbAppUser = await _unitOfWork.AppUserRepository.GetAsync(c => c.Id == id);

            if (dbAppUser == null)
                throw new NotFoundException($"App User Cannot be found By id = {id}");

            _unitOfWork.AppUserRepository.Remove(dbAppUser);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<List<UserListDTO>>(await _unitOfWork.AppUserRepository.GetAllByExAsync(x => x.UserName != username));
        }

        public async Task ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            if (resetPasswordDTO.Id == null)
                throw new BadRequestException("Id is null!");

            AppUser appUser = await _userManager.FindByIdAsync(resetPasswordDTO.Id);

            if (appUser == null)
                throw new NotFoundException("User cannot be found!");

            if (await _userManager.CheckPasswordAsync(appUser, resetPasswordDTO.NewPassword))
                throw new BadRequestException("This password is not appropriate or is same as old!");

            string token = await _userManager.GeneratePasswordResetTokenAsync(appUser);

            IdentityResult result = await _userManager.ResetPasswordAsync(appUser, token, resetPasswordDTO.NewPassword);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    throw new BadRequestException(error.Description);
                }
            }
        }
    }
}
