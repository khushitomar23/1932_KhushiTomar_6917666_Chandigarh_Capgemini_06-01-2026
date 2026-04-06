using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Department name must be between 3 and 50 characters")]
        public string DepartmentName { get; set; }

        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters")]
        public string Description { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
    }
}
