namespace ECommerceSite.Models.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? DateOfBirth { get; set; }

        // One-to-One relationship
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
