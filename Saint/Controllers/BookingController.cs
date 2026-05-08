using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Saint.Data;
using Saint.Models;
using Saint.Models.ViewModels;

namespace Saint.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BookingController( ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Book(int roomTypeId, DateTime checkIn, DateTime checkOut)
        {
            var roomType = _context.RoomTypes
                .Include(t => t.RoomImages)
                .FirstOrDefault(r => r.Id == roomTypeId);

            var hotelPolicies = _context.HotelPolicies.ToList();


            if (roomType == null)
            {
                return NotFound();
            }

            var nights = (checkOut - checkIn).Days;
            if (nights <= 0) nights = 1;

            var roomCost = nights * roomType.Price; // Replace "2" with actual price logic if needed
            var occupancy = roomType.Capacity;
            var tax = Math.Round(roomCost * 0.19m, 2);

            var totalCost = roomCost + tax;
            var model = new BookingWizardViewModel()
            {
                RoomTypeId = roomTypeId,
                RoomTypeName = roomType.Name,
                CheckIn = checkIn,
                CheckOut = checkOut,
                Nights = nights,
                Policies = hotelPolicies,
                RoomCost = roomCost,
                Tax = tax,
                Occupancy = occupancy,
                TotalCost = totalCost,
                RoomImages = roomType.RoomImages.Select(r => r.ImageUrl).ToList()
            };

            return View(model);
        }


    }
}
