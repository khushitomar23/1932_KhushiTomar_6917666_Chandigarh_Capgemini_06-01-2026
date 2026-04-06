using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.Models
{
    public class Appointment
    {
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Patient ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Patient ID must be valid")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Doctor ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Doctor ID must be valid")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        [DataType(DataType.DateTime)]
        [CustomValidation(typeof(Appointment), nameof(ValidateFutureDate))]
        public DateTime AppointmentDate { get; set; }

        [RegularExpression(@"^(Booked|Completed|Cancelled)$", ErrorMessage = "Status must be Booked, Completed, or Cancelled")]
        public string? Status { get; set; } // Booked, Completed, Cancelled

        [StringLength(100, ErrorMessage = "Patient name must not exceed 100 characters")]
        public string? PatientName { get; set; }

        [StringLength(500, ErrorMessage = "Problem description must not exceed 500 characters")]
        public string? ProblemDescription { get; set; }

        public virtual User Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Prescription Prescription { get; set; }
        public virtual Bill Bill { get; set; }

        public static ValidationResult ValidateFutureDate(DateTime appointmentDate, ValidationContext context)
        {
            if (appointmentDate <= DateTime.Now)
            {
                return new ValidationResult("Appointment date must be in the future");
            }
            return ValidationResult.Success;
        }
    }
}
