using System.ComponentModel.DataAnnotations;

namespace HealthcareShared.Models
{
    public class Bill
    {
        public int BillId { get; set; }

        [Required(ErrorMessage = "Appointment ID is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Appointment ID must be valid")]
        public int AppointmentId { get; set; }

        [Required(ErrorMessage = "Consultation fee is required")]
        [Range(0, 10000, ErrorMessage = "Consultation fee must be between 0 and 10000")]
        [DataType(DataType.Currency)]
        public decimal ConsultationFee { get; set; }

        [Required(ErrorMessage = "Medicine charges are required")]
        [Range(0, 10000, ErrorMessage = "Medicine charges must be between 0 and 10000")]
        [DataType(DataType.Currency)]
        public decimal MedicineCharges { get; set; }

        [Required(ErrorMessage = "Total amount is required")]
        [Range(0, 20000, ErrorMessage = "Total amount must be between 0 and 20000")]
        [DataType(DataType.Currency)]
        public decimal TotalAmount { get; set; }

        [Required(ErrorMessage = "Payment status is required")]
        [RegularExpression(@"^(Paid|Unpaid)$", ErrorMessage = "Payment status must be Paid or Unpaid")]
        public string PaymentStatus { get; set; } // Paid, Unpaid

        public virtual Appointment Appointment { get; set; }
    }
}
