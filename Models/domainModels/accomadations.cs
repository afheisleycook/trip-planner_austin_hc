namespace trip_planner_austin_hc.Models.domainModels
{
    public class Accommodation
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        
        // skip navigation property for one-to-many with Trip
        public ICollection<Trip> Trips { get; set; } = new HashSet<Trip>();
    }
}
