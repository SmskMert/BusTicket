using BusTicket.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BusTicket.Data.Identity
{
    public class Context_Identity : IdentityDbContext<User>
    {
        public Context_Identity(DbContextOptions<Context_Identity> options):base(options)
        {
        }
    }
}
