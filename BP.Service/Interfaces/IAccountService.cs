using BP.Core;
using BP.Service.DTOs.AccountDTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BP.Service.Interfaces
{
    public interface IAccountService
    {
        Task<UserDTO> Login(LoginDTO loginDTO);
        Task<UserDTO> Register(RegisterDTO registerDTO);
    }
}
