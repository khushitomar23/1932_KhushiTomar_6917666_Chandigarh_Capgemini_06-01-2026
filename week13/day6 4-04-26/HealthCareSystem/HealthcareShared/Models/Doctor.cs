using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "User ID must be valid")]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Department ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Department ID must be valid")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Specialization is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Specialization must be between 3 and 50 characters")]
        public string Specialization { get; set; }

        [Required(ErrorMessage = "Experience years is required")]
        [Range(0, 60, ErrorMessage = "Experience years must be between 0 and 60")]
        public int ExperienceYears { get; set; }

        [Required(ErrorMessage = "Availability is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Availability must be between 3 and 100 characters")]
        public string Availability { get; set; }

        public virtual User User { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
