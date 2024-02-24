namespace GBC_Travel_Group_35.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string UserEmail { get; set; } // Assuming you're tracking bookings by user email
        public int ItemId { get; set; } // This could be FlightId, HotelId, or CarRentalId based on the booking type
        public string ItemType { get; set; } // "Flight", "Hotel", or "CarRental"
        public DateTime BookingDate { get; set; }
        public decimal Price { get; set; }
        // Additional details like dates, pricing, confirmation number, etc.
    }

}
