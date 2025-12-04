using Microsoft.AspNetCore.Mvc;
using TripLog.Models;

namespace TripLog.Controllers
{
    public class AccommodationController : Controller
    {
        private Repository<Accommodation> data { get; set; }
        public AccommodationController(TripLogContext ctx) {
            data = new Repository<Accommodation>(ctx);
        }

        public IActionResult Index()
        {
            var accommodations = GetDataForView();
            return View(accommodations);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View(new Accommodation());
        }

        [HttpPost]
        public IActionResult Add(Accommodation model)
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
            var accommodation = data.Get(id)!;
            data.Delete(accommodation);
            try {
                data.Save();
                TempData["message"] = $"{accommodation.Name} deleted. ";

                return RedirectToAction("Index");
            }
            /*******************************************************************
            * If try to delete an accommodation that's associated with a trip, 
            * will get an exception, bc FK delete behavior is set to Restrict.            
            * In that case, notify user and re-display view.
            *******************************************************************/
            catch {
                TempData["message"] = $"Unable to delete {accommodation.Name} because it's associated with a Trip.";
                var destinations = GetDataForView();
                return View("Index", destinations);
            }
        }

        private IEnumerable<Accommodation> GetDataForView()
        {
            var accommodations = data.List(new QueryOptions<Accommodation>
            {
                Where = a => a.AccommodationId > 0, // don't include default accommodation
                OrderBy = a => a.Name
            });
            return accommodations;
        }
    }
}
