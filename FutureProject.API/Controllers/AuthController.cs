using FutureProject.Domain.Entities.DTOs;
using FutureProjectApplication.Abstraction.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FutureProject.API.Controllers.Identity
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseLogin>> Login(RequestLogin model)
        {
            var result = await _authService.GenerateToken(model);

            return Ok(result);
        }








    }
}
