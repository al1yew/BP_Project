using BP.Service.DTOs.UserDTOs;
using BP.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BP.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("getall")]
        public async Task<IActionResult> GetAll(string username)
        {
            return Ok(await _userService.GetAllAsync(username));
        }

        [HttpGet]
        [Route("{id?}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _userService.GetById(id));
        }

        [HttpGet]
        [Route("getbyname")]
        public async Task<IActionResult> GetByName(string username)
        {
            return Ok(await _userService.GetByName(username));
        }

        [HttpPost]
        public async Task<IActionResult> Post(UserPostDTO userPostDTO)
        {
            await _userService.CreateAsync(userPostDTO);

            return StatusCode(201);
        }

        [HttpPut]
        [Route("{id?}")]
        public async Task<IActionResult> Put(string id, UserPutDTO userPutDTO)
        {
            await _userService.UpdateAsync(id, userPutDTO);

            return Ok();
        }

        [HttpDelete]
        [Route("{id?}")]
        public async Task<IActionResult> Delete([FromQuery] string id, [FromQuery] string username)
        {
            return Ok(await _userService.DeleteAsync(id, username));
        }

        [HttpPost]
        [Route("resetpassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordDTO resetPasswordDTO)
        {
            await _userService.ResetPassword(resetPasswordDTO);

            return Ok();
        }
    }
}
