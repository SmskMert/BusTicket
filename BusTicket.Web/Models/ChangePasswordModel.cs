using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class ChangePasswordModel
    {
        [Display(Name ="Current Password")]
        [Required(ErrorMessage ="Current password must be provided.")]
        [DataType(DataType.Password)]
        public string? OldPassword { get; set; }

        [Display(Name = "New Password")]
        [Required(ErrorMessage = "New password must be provided.")]
        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [Display(Name = "New Repassword")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "New password must be reentered.")]
        [Compare("NewPassword", ErrorMessage = "Passwords does not match.")]
        public string? NewRePassword { get; set; }
    }
}
