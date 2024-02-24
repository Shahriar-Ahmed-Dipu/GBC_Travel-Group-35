using GBC_Travel_Group_35.Data;
using GBC_Travel_Group_35.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class BookingController : Controller
{
    public IActionResult Index()
    {
        return View(); // This should return the BookingPage view
    }


    private readonly ApplicationDbContext _context;

    public BookingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> SearchFlights(string airlineName, DateTime? departureTime, DateTime? arrivalTime, decimal? price)
    {
        var flightsQuery = _context.Flights.AsQueryable();

        if (!string.IsNullOrWhiteSpace(airlineName))
        {
            flightsQuery = flightsQuery.Where(f => f.AirlineName.Contains(airlineName));
        }
        if (departureTime.HasValue)
        {
            flightsQuery = flightsQuery.Where(f => f.DepartureTime >= departureTime.Value);
        }
        if (arrivalTime.HasValue)
        {
            flightsQuery = flightsQuery.Where(f => f.ArrivalTime <= arrivalTime.Value);
        }
        if (price.HasValue)
        {
            flightsQuery = flightsQuery.Where(f => f.Price <= price.Value);
        }

        var flights = await flightsQuery.ToListAsync();
        return View("SearchFlightsResults", flights); // Make sure to create this view to display the results
    }





























    [HttpGet]
    public async Task<IActionResult> SearchHotels(string hotelName, string location, decimal? pricePerNight, int? rating)
    {
        var hotelsQuery = _context.Hotels.AsQueryable();

        if (!string.IsNullOrWhiteSpace(hotelName))
        {
            hotelsQuery = hotelsQuery.Where(h => h.HotelName.Contains(hotelName));
        }
        if (!string.IsNullOrWhiteSpace(location))
        {
            hotelsQuery = hotelsQuery.Where(h => h.Location.Contains(location));
        }
        if (pricePerNight.HasValue)
        {
            hotelsQuery = hotelsQuery.Where(h => h.PricePerNight <= pricePerNight.Value);
        }
        if (rating.HasValue)
        {
            hotelsQuery = hotelsQuery.Where(h => h.Rating >= rating.Value);
        }

        var hotels = await hotelsQuery.ToListAsync();
        return View("SearchHotelsResults", hotels); // Ensure you have a view to display these results
    }


    [HttpGet]
    public async Task<IActionResult> SearchCars(string model, string rentalCompany, decimal? price, bool? isAvailable)
    {
        var carRentalsQuery = _context.CarRentals.AsQueryable();

        if (!string.IsNullOrWhiteSpace(model))
        {
            carRentalsQuery = carRentalsQuery.Where(c => c.Model.Contains(model));
        }
        if (!string.IsNullOrWhiteSpace(rentalCompany))
        {
            carRentalsQuery = carRentalsQuery.Where(c => c.RentalCompany.Contains(rentalCompany));
        }
        if (price.HasValue)
        {
            carRentalsQuery = carRentalsQuery.Where(c => c.Price <= price.Value);
        }
        if (isAvailable.HasValue)
        {
            carRentalsQuery = carRentalsQuery.Where(c => c.IsAvailable == isAvailable.Value);
        }

        var carRentals = await carRentalsQuery.ToListAsync();
        return View("SearchCarsResults", carRentals); // Ensure you have a view to display these results
    }




























    

    // Action method to handle booking a flight
    [HttpPost]
    public async Task<IActionResult> BookFlight(FlightBookingViewModel model)
    {
        var booking = new Booking
        {
            UserEmail = model.UserEmail,
            ItemId = model.FlightId,
            ItemType = "Flight",
            BookingDate = DateTime.Now,
            Price = model.Price,
            // Set other necessary properties
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return RedirectToAction("BookingConfirmation", new { id = booking.Id });
    }

    // Action method to handle booking a hotel
    [HttpPost]
    public async Task<IActionResult> BookHotel(HotelBookingViewModel model)
    {
        var booking = new Booking
        {
            UserEmail = model.UserEmail,
            ItemId = model.HotelId,
            ItemType = "Hotel",
            BookingDate = DateTime.Now,
            Price = model.Price,
            // Set other necessary properties
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return RedirectToAction("BookingConfirmation", new { id = booking.Id });
    }

    // Action method to handle booking a car rental
    [HttpPost]
    public async Task<IActionResult> BookCarRental(CarRentalBookingViewModel model)
    {
        var booking = new Booking
        {
            UserEmail = model.UserEmail,
            ItemId = model.CarRentalId,
            ItemType = "CarRental",
            BookingDate = DateTime.Now,
            Price = model.Price,
            // Set other necessary properties
        };

        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();

        return RedirectToAction("BookingConfirmation", new { id = booking.Id });
    }

    // Action method to display booking confirmation
    public IActionResult BookingConfirmation(int id)
    {
        // Retrieve booking details from the database using the id
        var booking = _context.Bookings.Find(id);
        if (booking == null)
        {
            // Handle case where booking is not found
            return NotFound();
        }

        // Pass the booking object to the view
        return View(booking);
    }












}
