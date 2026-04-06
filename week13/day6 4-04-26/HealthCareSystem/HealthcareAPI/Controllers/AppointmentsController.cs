using HealthcareShared.DTOs;
using HealthcareAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HealthcareAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentsController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookAppointment([FromQuery] int patientId, [FromBody] CreateAppointmentDto dto)
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

                // Validate patient ID
                if (patientId <= 0)
                    return BadRequest(new { success = false, message = "Valid patient ID is required" });

                // Validate DTO
                if (dto == null)
                    return BadRequest(new { success = false, message = "Request body is required" });

                var appointment = await _appointmentService.BookAppointmentAsync(patientId, dto);
                return Ok(new { success = true, message = "Appointment booked successfully", data = appointment });
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"InvalidOperationException: {ex.Message}\n{ex.StackTrace}");
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.GetType().Name}: {ex.Message}\n{ex.StackTrace}");
                return StatusCode(500, new { success = false, message = "An error occurred while booking appointment", error = $"{ex.GetType().Name}: {ex.Message}", stackTrace = ex.StackTrace });
            }
        }

        [HttpGet("patient/{patientId}")]
        public async Task<IActionResult> GetPatientAppointments(int patientId)
        {
            try
            {
                // Validate patient ID
                if (patientId <= 0)
                    return BadRequest(new { success = false, message = "Valid patient ID is required" });

                var appointments = await _appointmentService.GetPatientAppointmentsAsync(patientId);
                return Ok(new { success = true, data = appointments });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while retrieving appointments", error = ex.Message });
            }
        }

        [HttpPatch("{appointmentId}/cancel")]
        public async Task<IActionResult> CancelAppointment(int appointmentId)
        {
            try
            {
                // Validate appointment ID
                if (appointmentId <= 0)
                    return BadRequest(new { success = false, message = "Valid appointment ID is required" });

                var appointment = await _appointmentService.CancelAppointmentAsync(appointmentId);
                return Ok(new { success = true, message = "Appointment cancelled successfully", data = appointment });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while cancelling appointment", error = ex.Message });
            }
        }

        [HttpGet("doctor/{doctorId}")]
        public async Task<IActionResult> GetDoctorAppointments(int doctorId)
        {
            try
            {
                // Validate doctor ID
                if (doctorId <= 0)
                    return BadRequest(new { success = false, message = "Valid doctor ID is required" });

                var appointments = await _appointmentService.GetDoctorAppointmentsAsync(doctorId);
                return Ok(new { success = true, data = appointments });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while retrieving appointments", error = ex.Message });
            }
        }
    }
}
