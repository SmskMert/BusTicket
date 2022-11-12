
namespace BusTicket.Web.Models
{
    public class UserWithRolesModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
