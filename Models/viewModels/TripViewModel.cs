using trip_planner_austin_hc.Models.domainModels;
using TripLog.Controllers;

namespace trip_planner_austin_hc.Models.viewModels
{
    public class TripViewModel
    {
      
        
        public Trip Trip { get; set; } = new Trip();
        public int PageNumber { get; set; }
        public IEnumerable<accomadations> Accommodations { get; internal set; }
        internal IEnumerable<Destination> Destinations { get; set; }
    }
}
