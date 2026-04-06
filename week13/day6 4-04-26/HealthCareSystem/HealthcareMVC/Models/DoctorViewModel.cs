namespace HealthcareMVC.Models
{
    public class DoctorViewModel
    {
        public int DoctorId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public string Specialization { get; set; }
        public int ExperienceYears { get; set; }
        public string Availability { get; set; }
    }
}
