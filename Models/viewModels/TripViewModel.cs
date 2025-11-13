using trip_planner_austin_hc.Models.domainModels;

namespace trip_planner_austin_hc.Models.viewModels
{
    public class TripViewModel
    {
      
        
        public Trip Trip { get; set; } = new Trip();
        public int PageNumber { get; set; }
    }
}
