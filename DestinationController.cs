using Microsoft.AspNetCore.Mvc;
using trip_planner_austin_hc.Models;
using trip_planner_austin_hc.Models.dataAccess;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class DestinationController : Controller
    {
        private Repository<Destination> data { get; set; }
        public DestinationController(TripContext ctx) {
            data = new Repository<Destination>(ctx);
        }

        public IActionResult Index()
        {
            var destinations = GetDataForView();
            return View(destinations);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Destination());
        }

        [HttpPost]
        public IActionResult Add(Destination model)
        {
            if (ModelState.IsValid)
            {
                data.Insert(model);
                data.Save();
                TempData["message"] = $"{model.Name} added. ";

                return RedirectToAction("Index");
            } 
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var destination = data.Get(id)!;
            data.Delete(destination);
            try {
                data.Save();
                TempData["message"] = $"{destination.Name} deleted. ";

                return RedirectToAction("Index");
            }
            /*******************************************************************
            * If try to delete a destination that's associated with a trip, 
            * will get an exception, bc FK delete behavior is set to Restrict.            
            * In that case, notify user and re-display view.
            *******************************************************************/
            catch {
                TempData["message"] = $"Unable to delete {destination.Name} because it's associated with a Trip.";
                var destinations = GetDataForView();
                return View("Index", destinations);
            }
        }

        private IEnumerable<Destination> GetDataForView()
        {
            var destinations = data.List(new QueryOptions<Destination>
            {
                OrderBy = d => d.Name
            });
            return destinations;
        }
    }
}
