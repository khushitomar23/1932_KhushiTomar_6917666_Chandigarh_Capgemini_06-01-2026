using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.DTOs
{
    public class UpdatePatientDto
    {
        [StringLength(100)]
        public string FullName { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
