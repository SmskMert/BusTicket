using BusTicket.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class TripSearchModel
    {
        [Required(ErrorMessage ="Please Select an Origin.")]
        public string? Origin { get; set; }

        [Required(ErrorMessage = "Please Select a Destination.")]
        public string? Destination { get; set; }

        [Required(ErrorMessage = "Please Select a Date.")]
        public string? Date { get; set; }
        public List<string>? StartingPoints { get; set; } = null!;
        public List<string>? Destinations { get; set; } = null!;
    }
}
