using trip_planner_austin_hc.Models.domainModels;

namespace trip_planner_austin_hc.Models.viewModels
{
    public class TripViewModel
    {
        public Trip Trip { get; set; } = new Trip();
        public int PageNumber { get; set; }
        public IEnumerable<Accommodation> Accommodations { get; set; } = new List<Accommodation>();
        public IEnumerable<Destination> Destinations { get; set; } = new List<Destination>();
        public IEnumerable<Activity> Activities { get; set; } = new List<Activity>();
        public int[] SelectedActivities { get; set; } = Array.Empty<int>();
    }
}
