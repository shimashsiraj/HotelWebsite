using Microsoft.AspNetCore.Mvc;
using Saint.Data;
using Saint.Models;
using Saint.Models.AdminViewModel;

namespace Saint.Controllers
{
    public class AdminViewController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminViewController(ApplicationDbContext context)
        {
            _context = context;
        }




        public IActionResult AdminView()
        {
            var model = new AdminViewModel
            {
                Rooms = _context.Rooms.ToList(),
                RoomTypes = _context.RoomTypes.ToList()
                //RoomImages = _context.RoomImages.ToList()
            };

            return View(model);
        }
    }
}
