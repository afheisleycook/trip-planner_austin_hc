using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using trip_planner_austin_hc.Models;


namespace trip_planner_austin_hc.Controllers
{   
    public class HomeController : Controller
    {
        private readonly TripContext _context;

        public HomeController(TripContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var trips = _context.trips
                .Include(t => t.Destination)
                .Include(t => t.Accommodation)
                .Include(t => t.Activities)
                .ToList();
            return View(trips);
        }
     
    }
}
    