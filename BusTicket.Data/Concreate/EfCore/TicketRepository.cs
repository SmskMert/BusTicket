using BusTicket.Data.Abstract;
using BusTicket.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Concreate.EfCore
{
    public class TicketRepository : GenericRepository<Ticket>, ITicketRepository
    {
        public Context_BusTicket Context {
            get
            {
                return _context as Context_BusTicket;
            }
        }

        public TicketRepository(Context_BusTicket Context) : base(Context)
        {
        }

        public async Task<Ticket> GetTicketWithTrip(int id)
        {
            return await Context.Tickets
                .Where(e => e.Id == id)
                .Include(e => e.Trip)
                .ThenInclude(e => e.MidLine)
                .ThenInclude(e=>e.Line)
                .Include(e => e.Trip.TripDetail)
                .FirstOrDefaultAsync();
        }
    }
}
