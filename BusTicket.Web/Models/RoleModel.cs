using System.ComponentModel.DataAnnotations;

namespace BusTicket.Web.Models
{
    public class RoleModel
    {
        public string? Id { get; set; }
        [Required(ErrorMessage ="Role name must be provided")]
        [StringLength(20, MinimumLength =3, ErrorMessage ="Role length to be between 3 to 20")]
        public string? Name { get; set; }
    }
}
