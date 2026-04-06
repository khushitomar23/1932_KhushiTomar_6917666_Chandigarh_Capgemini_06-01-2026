using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UniversityManagement.Models
{
    [Table("tblCourse")]
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string Title { get; set; }
        public int Credits { get; set; }

        public int InstructorId { get; set; }

        
    }
}
