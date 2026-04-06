using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.DTOs
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Status { get; set; }
        public string PatientName { get; set; }
        public string? ProblemDescription { get; set; }
    }

    public class CreateAppointmentDto
    {
        [Required]
        public int DoctorId { get; set; }

        [Required]
        public DateTime AppointmentDate { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Problem description must be between 5 and 500 characters.")]
        public string ProblemDescription { get; set; }

        // Custom validation method
        public bool ValidateFutureDate()
        {
            return AppointmentDate > DateTime.Now;
        }
    }
}
