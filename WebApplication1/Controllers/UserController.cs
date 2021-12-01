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

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] CreateUserDTO create)
        {
            var user = await _user.RegisterUser(create);
            return Created($"api/users/{user.UserId}", user);
        }
        [HttpPost("/login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserDTO login)
        {
            await _user.Login(login);
            return Ok();
        }
    }
}
