using BusTicket.Entity;
using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class PassangerDetailsModel
    {
        public string? TripId { get; set; }
        public string? SelectedSeatNo { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage ="First name must be provided.")]
        public string? FName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "Last name must be provided.")]
        public string? LName { get; set; }

        [Required(ErrorMessage = "Gender must be selected.")]
        public string? Gender { get; set; }

        [Required(ErrorMessage = "Age must be provided.")]
        public string? Age { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone number must be provided.")]
        [DataType(DataType.PhoneNumber,ErrorMessage ="Invalid Phone Number.")]
        public string? Contact { get; set; }

        [Required(ErrorMessage = "Email must be provided.")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        public Customer? Customer { get; set; } = null!;
        public bool SavePassangerDetails { get; set; }

        public decimal TotalPrice { get; set; }

    }
}
