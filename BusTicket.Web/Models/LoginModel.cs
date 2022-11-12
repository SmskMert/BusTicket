using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "User Name is required.")]
        [Display(Name = "User Name")]
        public string? UserName { get; set; }

        //[Required(ErrorMessage = "Email is required.")]
        //[DataType(DataType.EmailAddress)]
        //public string? Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name ="Keep me signed in")]
        public bool IsPersistent { get; set; }

        public string? ReturnUrl { get; set; }

    }
}
