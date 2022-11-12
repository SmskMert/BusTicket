using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Entity
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Gender { get; set; }
        public string? Age { get; set; }
        public string? Contact { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public List<Ticket> Tickets { get; set; } = null!;

    }
}
