using HealthcareShared.DTOs;
using HealthcareAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HealthcareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorsController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctorsAsync();
                return Ok(new { success = true, data = doctors });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("department/{departmentId}")]
        public async Task<IActionResult> GetDoctorsByDepartment(int departmentId)
        {
            try
            {
                var doctors = await _doctorService.GetDoctorsByDepartmentAsync(departmentId);
                return Ok(new { success = true, data = doctors });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetDoctorById(int doctorId)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByIdAsync(doctorId);
                if (doctor == null)
                    return NotFound(new { success = false, message = "Doctor not found" });

                return Ok(new { success = true, data = doctor });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpGet("byuser/{userId}")]
        public async Task<IActionResult> GetDoctorByUserId(int userId)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorByUserIdAsync(userId);
                if (doctor == null)
                    return NotFound(new { success = false, message = "Doctor not found for this user" });

                return Ok(new { success = true, data = doctor });
            }
            catch (Exception ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctor([FromBody] CreateDoctorDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    return BadRequest(new { success = false, message = "Validation failed", errors = errors.Select(e => e.ErrorMessage).ToList() });
                }

                var doctor = await _doctorService.CreateDoctorAsync(dto);
                return Ok(new { success = true, message = "Doctor created successfully", data = doctor });
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

        [HttpPut("{doctorId}")]
        public async Task<IActionResult> UpdateDoctor(int doctorId, [FromBody] UpdateDoctorDto dto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    return BadRequest(new { success = false, message = "Validation failed", errors = errors.Select(e => e.ErrorMessage).ToList() });
                }

                var doctor = await _doctorService.UpdateDoctorAsync(doctorId, dto);
                return Ok(new { success = true, message = "Doctor updated successfully", data = doctor });
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

        [HttpDelete("{doctorId}")]
        public async Task<IActionResult> DeleteDoctor(int doctorId)
        {
            try
            {
                await _doctorService.DeleteDoctorAsync(doctorId);
                return Ok(new { success = true, message = "Doctor deleted successfully" });
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
