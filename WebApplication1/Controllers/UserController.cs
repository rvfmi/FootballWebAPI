using Infrastructure.Interfaces;
using Infrastructure.ModelsDTO.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _user;

        public UserController(IUserRepository user)
        {
            _user = user;
        }

        [HttpPost("/RegisterUser")]
        public async Task<IActionResult> AddUser([FromBody] CreateUserDTO create)
        {
            var user = await _user.RegisterUser(create);
            return Created($"api/users/{user.UserId}", user);
        }
        [HttpPut("/UpdatePassword")]
        public async Task<IActionResult> UpdatePassword([FromBody] ChangePasswordDTO password, string email)
        {
           var pass=  await _user.ChangePassword(password, email);
           return Ok(pass);
        }
        [HttpPost("/Login")]
        public ActionResult Login([FromBody] LoginUserDTO login)
        {
            var token = _user.GenerateJwtToken(login);
            return Ok(token);
        }
    }
}
