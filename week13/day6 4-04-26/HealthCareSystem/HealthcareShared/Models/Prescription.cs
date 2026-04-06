using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.Models
{
    public class Prescription
    {
        public int PrescriptionId { get; set; }

        [Required(ErrorMessage = "Appointment ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Appointment ID must be valid")]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Diagnosis is required")]
        [StringLength(500, MinimumLength = 5, ErrorMessage = "Diagnosis must be between 5 and 500 characters")]
        public string Diagnosis { get; set; }

        [Required(ErrorMessage = "Medicines are required")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Medicines must be between 3 and 1000 characters")]
        public string Medicines { get; set; }

        [StringLength(1000, ErrorMessage = "Notes cannot exceed 1000 characters")]
        public string Notes { get; set; }

        public virtual Appointment Appointment { get; set; }
    }
}
