namespace GBC_Travel_Group_35.Models
{
    public class Flight
    {
        public int FlightId { get; set; } // Primary key
        public string AirlineName { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public decimal Price { get; set; }
    }
}
