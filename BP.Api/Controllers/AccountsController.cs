using BP.Core.Entities;
using BP.Service.DTOs.AccountDTOs;
using BP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BP.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
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





















        //[Route("create")]
        //public async Task<IActionResult> Create()
        //{
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
        //    await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });

        //    AppUser appUser = new AppUser
        //    {
        //        Name = "Vasif",
        //        Surname = "Aliyev",
        //        UserName = "SuperAdmin",
        //        Email = "admin@admin"
        //    };

        //    IdentityResult identityResult = await _userManager.CreateAsync(appUser, "Admin123");

        //    await _userManager.AddToRoleAsync(appUser, "SuperAdmin");

        //    return Content("yaratdiq superadmini");
        //}

        //[Route("create")]
        //public async Task<IActionResult> Create()
        //{
        //    AppUser appUser = new AppUser
        //    {
        //        Name = "Vasif",
        //        Surname = "Aliyev",
        //        UserName = "vasifaliyev",
        //        Email = "vasifja@code.edu.az"
        //    };

        //    IdentityResult identityResult = await _userManager.CreateAsync(appUser, "SalamBaku123");

        //    await _userManager.AddToRoleAsync(appUser, "Member");

        //    return Content("yaratdiq memberi");
        //}
    }
}
