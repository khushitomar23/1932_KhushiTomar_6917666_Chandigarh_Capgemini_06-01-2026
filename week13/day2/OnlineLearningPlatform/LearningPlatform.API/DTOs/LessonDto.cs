using System.ComponentModel.DataAnnotations;

namespace LearningPlatform.API.DTOs
{
    public class LessonDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public int Order { get; set; }
        public int CourseId { get; set; }
    }

    public class CreateLessonDto
    {
        [Required(ErrorMessage = "Lesson title is required")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required")]
        public string Content { get; set; } = string.Empty;

        public int Order { get; set; }
    }
}