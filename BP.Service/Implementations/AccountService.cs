using AutoMapper;
using BP.Core.Entities;
using BP.Service.DTOs.AccountDTOs;
using BP.Service.Exceptions;
using BP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private IConfiguration Configuration { get; }

        public AccountService(UserManager<AppUser> userManager, IMapper mapper, IConfiguration configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            Configuration = configuration;
        }

        public async Task<UserDTO> Login(LoginDTO loginDTO)
        {
            AppUser appUser = await _userManager.Users.FirstOrDefaultAsync(u => (u.NormalizedEmail == loginDTO.Login.Trim().ToUpperInvariant() || u.NormalizedUserName == loginDTO.Login.Trim().ToUpperInvariant()));

            if (appUser == null)
                throw new BadRequestException("Login is wrong!");

            if (!await _userManager.CheckPasswordAsync(appUser, loginDTO.Password))
                throw new BadRequestException("Password is wrong!");

            return new UserDTO
            {
                Email = appUser.Email,
                Name = appUser.Name,
                Surname = appUser.Surname,
                UserName = appUser.UserName,
                Token = await GenerateToken(appUser)
            };
        }

        public async Task<UserDTO> Register(RegisterDTO registerDTO)
        {
            AppUser appUser = _mapper.Map<AppUser>(registerDTO);

            IdentityResult result = await _userManager.CreateAsync(appUser, registerDTO.Password);

            if (!result.Succeeded)
            {
                foreach (IdentityError error in result.Errors)
                {
                    throw new BadRequestException(error.Description);
                }
            }

            result = await _userManager.AddToRoleAsync(appUser, "Member");

            return new UserDTO
            {
                Email = registerDTO.Email,
                Name = registerDTO.Name,
                Surname = registerDTO.Surname,
                UserName = registerDTO.UserName,
                Token = await GenerateToken(appUser)
            };

            //etot action poka shto ne ispolzuyetsa, prosto na budusheye sebe napisal. tut ispolzuyem tolko login i createtoken
        }

        public async Task<string> GenerateToken(AppUser appUser)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim(ClaimTypes.Name, appUser.Name),
                new Claim(ClaimTypes.Surname, appUser.Surname),
                new Claim(ClaimTypes.Email, appUser.Email)
            };

            IList<string> roles = await _userManager.GetRolesAsync(appUser);

            foreach (string role in roles)
            {
                Claim claim = new Claim(ClaimTypes.Role, role);
                claims.Add(claim);
            }

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration.GetSection("JWT:SecretKey").Value));

            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha512);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: Configuration.GetSection("JWT:Issuer").Value,
                audience: Configuration.GetSection("JWT:Audience").Value,
                claims: claims,
                expires: DateTime.Now.AddHours(4),
                signingCredentials: signingCredentials
            );

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            string token = jwtSecurityTokenHandler.WriteToken(jwtSecurityToken);

            return token;
        }
    }
}
