using Microsoft.EntityFrameworkCore;
using trip_planner_austin_hc.Models.domainModels;
namespace trip_planner_austin_hc.Models
{
    public class TripContext : DbContext
    {
        public TripContext(DbContextOptions<TripContext> options)
            : base(options)
        {
        }
        public DbSet<Trip> trips { get; set; } = null!;
    }
}