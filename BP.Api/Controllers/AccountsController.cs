using BP.Core.Entities;
using BP.Service.DTOs.AccountDTOs;
using BP.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountsController(IAccountService accountService, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _accountService = accountService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            return Ok(await _accountService.Register(registerDTO));
            //etot action poka shto ne ispolzuyetsa, prosto na budusheye sebe napisal. tut ispolzuyem tolko login i createtoken
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            return Ok(await _accountService.Login(loginDTO));
        }



        #region Created Roles

        //[Route("createroles")]
        //public async Task<IActionResult> CreateRoles()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    return Content("Salammmmm");
        //}

        #endregion

        #region Created Admin

        //[Route("createadmin")]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Name = "Vasif",
        //        Surname = "Aliyev",
        //        UserName = "Vasif1",
        //        Email = "admin@admin"
        //    };

        //    await _userManager.CreateAsync(appUser, "Admin123");

        //    await _userManager.AddToRoleAsync(appUser, "Admin");

        //    return Content("Admin est ");
        //}

        #endregion

        #region Created Kamran

        //[Route("createkamran")]
        //public async Task<IActionResult> CreateKamran()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Name = "Kamran",
        //        Surname = "Amirli",
        //        UserName = "Kamran1",
        //        Email = "kamran@kamran"
        //    };

        //    await _userManager.CreateAsync(appUser, "Admin123");

        //    await _userManager.AddToRoleAsync(appUser, "Admin");

        //    return Content("Kamran est ");
        //}

        #endregion
    }
}
