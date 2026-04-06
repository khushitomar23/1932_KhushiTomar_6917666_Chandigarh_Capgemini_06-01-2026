namespace LearningPlatform.API.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
        public int CourseId { get; set; }
        public Course Course { get; set; } = null!;
    }
}