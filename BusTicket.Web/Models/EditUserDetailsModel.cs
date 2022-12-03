using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class EditUserDetailsModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage = "First Name is required.")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "First Name length to be 3-25!")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [Display(Name = "Last Name")]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "Last Name length to be 3-25!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required.")]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

    }
}
