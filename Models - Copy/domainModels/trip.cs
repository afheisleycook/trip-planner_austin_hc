using System.ComponentModel.DataAnnotations;
namespace trip_planner_austin_hc.Models.domainModels
{
    public class Trip
    {
        public int TripId { get; set; }
        [Required(ErrorMessage = "Please enter a trip name.")]
        public string Destination { get; set; } = string.Empty;
        [Required(ErrorMessage = "Please enter an accommodation name.")]
        public string Accommodation { get; set; } = string.Empty;  
        [Required(ErrorMessage = "Please enter a start date.")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please enter an end date.")]
        public DateTime EndDate { get; set; }
        public string? AccommodationPhone { get; set; } = string.Empty;
        public string? AccommodationEmail { get; set; } = string.Empty;
        public string? Activity1 { get; set; } = string.Empty;
        public string? Activity2 { get; set; } = string.Empty;
        public string? Activity3 { get; set; } = string.Empty;

    }

}