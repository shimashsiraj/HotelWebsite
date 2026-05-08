using Microsoft.AspNetCore.Mvc;
using Saint.Data;
using Saint.Models;

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
            ViewData["ShowNavbar"] = true;
            return View();
        }

        public IActionResult HotelPolicy()
        {
            ViewData["ShowNavbar"] = true;
            return View();
        }

    }
}
