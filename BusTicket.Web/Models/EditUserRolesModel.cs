using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class EditUserRolesModel
    {
        public string UserId { get; set; }
        public string? UserName { get; set; }
        public IList<string>? UserRoles { get; set; }

        [Required(ErrorMessage = "At least 1 role must be selected")]
        public string[] SelectedRoles { get; set; } = null!;
    }
}
