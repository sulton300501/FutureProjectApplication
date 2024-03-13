using FutureProject.Domain.Entities.DTOs;
using FutureProject.Domain.Entities.Models;
using FutureProject.Domain.Entities.ViewModel;
using FutureProjectApplication.Abstraction;
using FutureProjectApplication.Abstraction.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

      
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

      

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserViewModel>>> GetAllUsers()
        {
            var result = await _userService.GetAll();
            return Ok(result);
        }


        [HttpPost]
        public async Task<User> CreateUser(UserDTO model)
        {
            var result = await _userService.Create(model);
            return result;
        }
    }
}

