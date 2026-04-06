using HealthcareShared.DTOs;
using HealthcareAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                // Validate ModelState
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    return BadRequest(new 
                    { 
                        success = false, 
                        message = "Validation failed",
                        errors = errors.Select(e => e.ErrorMessage).ToList()
                    });
                }

                // Validate DTO is not null
                if (registerDto == null)
                    return BadRequest(new { success = false, message = "Request body is required" });

                var user = await _authService.RegisterAsync(registerDto);
                return Ok(new { success = true, message = "Registration successful", data = user });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred during registration", error = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                // Validate ModelState
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    return BadRequest(new 
                    { 
                        success = false, 
                        message = "Validation failed",
                        errors = errors.Select(e => e.ErrorMessage).ToList()
                    });
                }

                // Validate DTO is not null
                if (loginDto == null)
                    return BadRequest(new { success = false, message = "Request body is required" });

                var (success, message, user) = await _authService.LoginAsync(loginDto);
                if (success)
                    return Ok(new { success = true, message = "Login successful", data = user });
                else
                    return Unauthorized(new { success = false, message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred during login", error = ex.Message });
            }
        }
    }
}
