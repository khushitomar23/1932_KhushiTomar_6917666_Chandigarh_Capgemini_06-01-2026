using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Full name must be between 2 and 100 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [RegularExpression(@"^(Admin|Doctor|Patient)$", ErrorMessage = "Role must be Admin, Doctor, or Patient")]
        public string Role { get; set; } // Admin, Doctor, Patient

        public DateTime CreatedAt { get; set; }

        public virtual Doctor Doctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
