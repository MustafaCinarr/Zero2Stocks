using Business.DTOs.Auth;
using Business.GenericRepository.IntServices;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;
        
        public AuthController(IAuthenticationService authenticationService)
        {
            _authService = authenticationService;
        }
        
        // Register Endpoint
        // POST : api/auth/register

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterMemberDto dto)
        {
            try
            {
                var result = await _authService.RegisterAsync(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }
        
        // Login Endpoint
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.LoginAsync(dto);
            
            if (token == null)
                return Unauthorized(new {message = "Email/Kullanıcı adı veya şifre yanlış"});

            return Ok(new { token });
        }
    }
