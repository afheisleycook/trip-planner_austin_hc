namespace trip_planner_austin_hc.Models.domainModels
{
    public class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        
        // skip navigation property for many-to-many with Trip
        public ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
