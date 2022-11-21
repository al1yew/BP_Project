using BP.Service.DTOs.UserDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Interfaces
{
    public interface IUserService
    {
        Task<List<UserListDTO>> GetAllAsync(string username);

        Task<UserGetDTO> GetById(string id);

        Task CreateAsync(UserPostDTO userPostDTO);

        Task UpdateAsync(string id, UserPutDTO userPutDTO);

        Task<List<UserListDTO>> DeleteAsync(string id, string username);

        Task ResetPassword(ResetPasswordDTO resetPasswordDTO);
    }
}
