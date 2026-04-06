namespace ECommerceSite.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; } = "User"; // Admin or User
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // One-to-One relationship
        public UserProfile Profile { get; set; }

        // One-to-Many relationship
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // RefreshToken relationship
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new List<RefreshToken>();
    }
}
