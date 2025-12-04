using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using NuGet.Protocol;
using trip_planner_austin_hc.Models;
using trip_planner_austin_hc.Models.dataAccess;
using trip_planner_austin_hc.Models.domainModels;
using trip_planner_austin_hc.Models.viewModels;

namespace TripLog.Controllers
{
    public class TripController : Controller
    {
        private trip_planner_austin_hc.Models.Repository<Trip> tripData { get; set; }
        private trip_planner_austin_hc.Models.Repository<Destination> destinationData { get; set; }
        private trip_planner_austin_hc.Models.Repository<Accommodation> accommodationData { get; set; }
        private trip_planner_austin_hc.Models.Repository<Activity> activityData { get; set; }

        public TripController(TripContext ctx)
        {
            tripData = new trip_planner_austin_hc.Models.Repository<Trip>(ctx);
            destinationData = new trip_planner_austin_hc.Models.dataAccess.Repository<Destination>(ctx);
            accommodationData = new trip_planner_austin_hc.Models.dataAccess.Repository<Accommodation>(ctx);
            activityData = new trip_planner_austin_hc.Models.Repository<Activity>(ctx);
        }

        public RedirectToActionResult Index() => RedirectToAction("Add", new { id = "page1" });

        public IActionResult Add(string id = "")
        {
            return Add(destinationData, id);
        }

        [HttpGet]
        public IActionResult Add(Repository<Destination> destinationData, string id = "")
        {
            var vm = new TripViewModel();

            if (id.ToLower() == "page1")
            {
                vm.PageNumber = 1;

                // get data for drop-downs
                vm.Destinations = destinationData.List(new QueryOptions<Destination>
                {
                    OrderBy = d => d.ToJson();
                });
                vm.Accommodations = accommodationData.List(new QueryOptions<Accommodation>
                {
                    OrderBy = a => a.Name
                });

                return View("Add1", vm);
            }
            else if (id.ToLower() == "page2")
            {
                vm.PageNumber = 2;

                // get destination for display by view (use Peek() so persists in TempData)
                int destID = (int)TempData.Peek(nameof(Trip.DestinationId))!;
                vm.Trip.Destination = destinationData.Get(destID);

                // get data for multi-select list
                vm.Activities = activityData.List(new QueryOptions<Activity>
                {
                    OrderBy = a => a.Name
                });

                return View("Add2", vm);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult Add(trip_planner_austin_hc.Models.Repository<Destination> destinationData, TripViewModel vm)
        {
            if (vm.PageNumber == 1)
            {
                if (ModelState.IsValid) // only page 1 has required data
                {
                    /***************************************************
                    * Store data in TempData and redirect (PRG pattern)
                    ****************************************************/
                    TempData[nameof(Trip.DestinationId)] = vm.Trip.DestinationId;
                    TempData[nameof(Trip.AccommodationId)] = vm.Trip.AccommodationId;
                    TempData[nameof(Trip.StartDate)] = vm.Trip.StartDate;
                    TempData[nameof(Trip.EndDate)] = vm.Trip.EndDate;
                    return RedirectToAction("Add", new { id = "Page2" });
                }
                else
                {
                    // get data for drop-downs
                    vm.Destinations = destinationData.List(new QueryOptions<Destination>
                    {
                        OrderBy = d => d.Name
                    });
                    vm.Accommodations = accommodationData.List(new QueryOptions<Accommodation>
                    {
                        OrderBy = a => a.Name
                    });

                    // re-display view
                    return View("Add1", vm);
                }
            }
            else if (vm.PageNumber == 2)
            {
                // get saved data from TempData (straight read)
                vm.Trip.DestinationId = (int)TempData[nameof(Trip.DestinationId)]!;
                vm.Trip.AccommodationId = (int)TempData[nameof(Trip.AccommodationId)]!;
                vm.Trip.StartDate = (DateTime)TempData[nameof(Trip.StartDate)]!;
                vm.Trip.EndDate = (DateTime)TempData[nameof(Trip.EndDate)]!;

                // add selected activities to trip
                foreach (int id in vm.SelectedActivities)
                {
                    var activity = activityData.Get(id)!;
                    if (activity != null)
                        vm.Trip.Activities.Add(activity);
                }

                // add trip to database
                tripData.Insert(vm.Trip);
                tripData.Save();

                // get destination data for notification message
                var dest = destinationData.Get(vm.Trip.DestinationId);
                TempData["message"] = $"Trip to {dest?.Name} added.";

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public RedirectToActionResult Cancel()
        {
            TempData.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public RedirectToActionResult Delete(int id)
        {
            Trip trip = tripData.Get(new QueryOptions<Trip>
            {
                Includes = "Destination",
                Where = t => t.TripId == id
            })!;

            if (trip != null)
            {
                // delete trip
                tripData.Delete(trip);
                tripData.Save();

                // set notification message
                TempData["message"] = $"Trip to {trip.Destination.Name} deleted.";
            }

            return RedirectToAction("Index", "Home");
        }
    }
}