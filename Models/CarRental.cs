namespace GBC_Travel_Group_35.Models
{
    public class CarRental
    {
        public int CarRentalId { get; set; } // Primary key
        public string Model { get; set; }
        public string RentalCompany { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }
    }
}
