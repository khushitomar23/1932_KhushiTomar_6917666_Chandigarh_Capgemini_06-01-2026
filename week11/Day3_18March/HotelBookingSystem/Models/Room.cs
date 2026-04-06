using System.Collections.Generic;

namespace HotelBookingSystem.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        public string? RoomNumber { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }
        public string? ImageUrl { get; set; }

        public List<Booking> Bookings { get; set; }
    }
}
