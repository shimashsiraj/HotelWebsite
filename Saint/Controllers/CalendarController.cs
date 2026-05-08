using Microsoft.AspNetCore.Mvc;

namespace Saint.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Calendar()
        {
            return View();
        }
    }
}
