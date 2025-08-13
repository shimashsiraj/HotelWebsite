using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Saint.Data;
using Saint.Models;

namespace Saint.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context )
        {
            _logger = logger;
            _context = context;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult Index(DateTime? checkIn, DateTime? checkOut, int? occupancy = 2)
        {
            bool hasCheckIn = Request.Query.ContainsKey("checkIn");
            bool hasCheckOut = Request.Query.ContainsKey("checkOut");
            bool hasOccupancy = Request.Query.ContainsKey("occupancy");

            if (!hasCheckIn || !hasCheckOut || !hasOccupancy)
            {
                checkIn = DateTime.Today;
                checkOut = DateTime.Today.AddDays(1);
                occupancy = 2;
            }

            // Now filter with final values
            var availableRoomTypes = _context.RoomTypes
                .Include(rt => rt.RoomImages)
                .Where(rt => rt.Capacity >= occupancy)
                .Where(rt => rt.Rooms.Any(r =>
                    r.Status == "Available" &&
                    !_context.Bookings.Any(b =>
                        b.RoomId == r.Id &&
                        (
                            (checkIn >= b.CheckIn && checkIn < b.CheckOut) ||
                            (checkOut > b.CheckIn && checkOut <= b.CheckOut)
                        )
                    )
                ))
                .ToList();

            ViewBag.CheckIn = checkIn.Value.ToString("yyyy-MM-dd");
            ViewBag.CheckOut = checkOut.Value.ToString("yyyy-MM-dd");
            ViewBag.Occupancy = occupancy;

            return View(availableRoomTypes);
        }


        //public IActionResult Index(DateTime? checkIn, DateTime? checkOut, int occupancy = 2)
        //{

        //    checkIn ??= DateTime.Today;

        //    checkOut ??= DateTime.Today.AddDays(1);


        //    var ci = checkIn.Value;
        //    var co = checkOut.Value;

        //    var allRoomTypes = _context.RoomTypes
        //        .Include(rt => rt.Rooms)
        //        .ToList();

        //    var step1 = allRoomTypes.Where(rt => rt.Capacity >= occupancy).ToList();
        //    var step2 = step1.Where(rt => rt.Rooms.Any(r => r.Status == "Available")).ToList();
        //    var step3 = step2.Where(rt => rt.Rooms.Any(r =>
        //        !_context.Bookings.Any(b =>
        //            b.RoomId == r.Id &&
        //            !(co <= b.CheckIn || ci >= b.CheckOut)
        //        )
        //    )).ToList();

        //    Console.WriteLine($"Total: {allRoomTypes.Count}, Cap OK: {step1.Count}, Status OK: {step2.Count}, Bookings OK: {step3.Count}");

        //    return View(step3);

        //}


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
