namespace ECommerceSite.Models.Entities
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsRevoked { get; set; } = false;

        // Foreign Key to User
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
