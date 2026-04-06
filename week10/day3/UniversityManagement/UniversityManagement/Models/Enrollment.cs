using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagement.Models
{
    [Table("tblEnrollment")]
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }

        public int StudentId { get; set; }
        public int CourseId { get; set; }

        public string Grade { get; set; }

        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
