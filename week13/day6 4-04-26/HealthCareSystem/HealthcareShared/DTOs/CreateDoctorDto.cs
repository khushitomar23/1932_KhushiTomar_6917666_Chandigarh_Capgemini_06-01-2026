using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.DTOs
{
    public class CreateDoctorDto
    {
        [Required]
        [StringLength(100)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [StringLength(200)]
        public string Specialization { get; set; }

        [Range(0, 50)]
        public int ExperienceYears { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Availability { get; set; }
    }

    public class UpdateDoctorDto
    {
        [StringLength(100)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public int DepartmentId { get; set; }

        [StringLength(200)]
        public string Specialization { get; set; }

        [Range(0, 50)]
        public int ExperienceYears { get; set; }

        [StringLength(100, MinimumLength = 3)]
        public string Availability { get; set; }
    }
}
