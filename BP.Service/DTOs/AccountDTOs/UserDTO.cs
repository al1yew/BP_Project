using System;
using System.Collections.Generic;
using System.Text;

namespace BP.Service.DTOs.AccountDTOs
{
    public class UserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
