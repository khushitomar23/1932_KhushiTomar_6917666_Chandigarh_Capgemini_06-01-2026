using System.ComponentModel.DataAnnotations;

namespace HealthcareMVC.Models
{
    public class AppointmentViewModel
    {
        public int AppointmentId { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public string DoctorName { get; set; }
        public string PatientName { get; set; }
        public string PatientEmail { get; set; }
        public string PatientPhone { get; set; }
        public string Department { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; }
        public string ProblemDescription { get; set; }
    }

    public class CreateAppointmentViewModel
    {
        [Required(ErrorMessage = "Doctor ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Doctor ID must be valid")]
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "Appointment date is required")]
        [DataType(DataType.DateTime)]
        [CustomValidation(typeof(CreateAppointmentViewModel), nameof(ValidateFutureDate))]
        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [StringLength(500, ErrorMessage = "Problem description must not exceed 500 characters")]
        [Display(Name = "Reason for Appointment")]
        public string ProblemDescription { get; set; }

        // Additional properties for display
        public string? DoctorName { get; set; }
        public string? DoctorDepartment { get; set; }
        public string? ConsultationFee { get; set; }

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
