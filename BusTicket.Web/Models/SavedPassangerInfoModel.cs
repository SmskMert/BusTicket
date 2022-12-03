using BusTicket.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class SavedPassangerInfoModel
    {
        public string? TripId { get; set; }
        public string? SelectedSeatNo { get; set; }

        public string? FName { get; set; }

        public string? LName { get; set; }

        public string? Gender { get; set; }

        public string? Age { get; set; }
  
        public string? Contact { get; set; }

        public string? Email { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
