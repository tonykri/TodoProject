using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TodoProject.Dto;
using TodoProject.Repositories;

namespace TodoProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepo _authRepo;
        public AuthController(IAuthRepo authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("signup")]
        public IActionResult Signup(UserSignupDto userData)
        {
            try
            {
                _authRepo.Signup(userData);
                return Ok("User signed up succesfully");
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userData)
        {
            try
            {
                string token = _authRepo.Login(userData);
                return Ok(token);
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            _authRepo.Logout();
            return Ok("User logged out succesfuly");
        }
    }
}