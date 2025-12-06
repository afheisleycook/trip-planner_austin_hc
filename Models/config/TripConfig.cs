using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using trip_planner_austin_hc.Models.domainModels;
namespace trip_planner_austin_hc.Models.config
{
    public class TripConfig : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> entity)
        {
            entity.HasOne(t => t.Destination)
               .WithMany(t => t.Trips)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(t => t.Accommodation)
                .WithMany(d => d.Trips)
                .OnDelete(DeleteBehavior.Restrict);

        }
        
    }

}
