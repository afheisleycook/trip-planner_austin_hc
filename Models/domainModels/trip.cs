using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace trip_planner_austin_hc.Models.domainModels
{
    public class Trip
    {
        public Trip() => Activities = new HashSet<Activity>();

        public int TripId { get; set; }

        [Range(1, 9999999, ErrorMessage = "Please select a destination.")]
        public int DestinationId { get; set; }                      // FK 
        [ValidateNever]
        public Destination Destination { get; set; } = null!;       // navigation property

        [Range(1, 9999999, ErrorMessage = "Please select your accommodations.")]
        public int AccommodationId { get; set; }                    // FK 
        [ValidateNever]
        public Accommodation Accommodation { get; set; } = null!;


        [Required(ErrorMessage = "Please enter the date your trip starts.")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Please enter the date your trip ends.")]
        public DateTime? EndDate { get; set; }

        // skip navigation property for many-to-many with Activity
        public ICollection<Activity> Activities { get; set; }
    }
}