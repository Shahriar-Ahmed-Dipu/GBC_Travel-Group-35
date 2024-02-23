namespace GBC_Travel_Group_35.Models
{
    public class Hotel
    {
        public int HotelId { get; set; } // Primary key
        public string HotelName { get; set; }
        public string Location { get; set; }
        public decimal PricePerNight { get; set; }
        public int Rating { get; set; }
    }
}
