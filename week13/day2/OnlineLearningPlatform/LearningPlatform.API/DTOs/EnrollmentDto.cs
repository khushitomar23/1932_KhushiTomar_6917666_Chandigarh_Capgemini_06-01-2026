using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.DTOs
{
    public class EnrollmentDto
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int CourseId { get; set; }
    }
}