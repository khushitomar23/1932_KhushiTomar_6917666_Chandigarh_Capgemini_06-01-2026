using HealthcareShared.DTOs;
using HealthcareAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace HealthcareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("patients")]
        public async Task<IActionResult> GetAllPatients()
        {
            try
            {
                var patients = await _userService.GetAllPatientsAsync();
                return Ok(new { success = true, data = patients });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while retrieving patients", error = ex.Message });
            }
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            try
            {
                if (userId <= 0)
                    return BadRequest(new { success = false, message = "Valid user ID is required" });

                var user = await _userService.GetUserByIdAsync(userId);
                if (user == null)
                    return NotFound(new { success = false, message = "User not found" });

                return Ok(new { success = true, data = user });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while retrieving user", error = ex.Message });
            }
        }

        [HttpPut("patients/{userId}")]
        public async Task<IActionResult> UpdatePatient(int userId, [FromBody] UpdatePatientDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    return BadRequest(new { success = false, message = "Validation failed", errors = errors.Select(e => e.ErrorMessage).ToList() });
                }

                var patient = await _userService.UpdatePatientAsync(userId, dto);
                return Ok(new { success = true, message = "Patient updated successfully", data = patient });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred", error = ex.Message });
            }
        }

        [HttpDelete("patients/{userId}")]
        public async Task<IActionResult> DeletePatient(int userId)
        {
            try
            {
                await _userService.DeletePatientAsync(userId);
                return Ok(new { success = true, message = "Patient deleted successfully" });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred", error = ex.Message });
            }
        }
    }
}
