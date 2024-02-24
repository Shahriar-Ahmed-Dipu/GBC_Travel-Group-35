namespace GBC_Travel_Group_35.Models
{
    public class HotelBookingViewModel
    {
        public string UserEmail { get; set; }
        public int HotelId { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public decimal Price { get; set; }
    }
}
