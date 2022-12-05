using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Abstract
{
    public interface ITicketRepository : IRepository<Ticket>
    {
        Task<Ticket> GetTicketWithTrip(int id);

        Task<List<Ticket>> GetTicketsByCustomerIdAsync(int id);
        Task<List<Ticket>> GetTicketsByPnrAsync(string pnr);
    }
}
