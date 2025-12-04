using Microsoft.AspNetCore.Mvc;

namespace trip_planner_austin_hc.Controllers
{
    public class DestinationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
