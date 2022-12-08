using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Abstract
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllAsync();

        Task<Ticket> GetByIdAsync(int id);

        Task CreateAsync(Ticket ticket);

        Task UpdateAsync(Ticket ticket);

        Task DeleteAsync(Ticket ticket);

        Task<Ticket> GetTicketWithTrip(int id);


        Task<List<Ticket>> GetTicketsByCustomerIdAsync(int id);
        Task<List<Ticket>> GetTicketsByUserNameAsync(string userName);
        Task<List<Ticket>> GetTicketsByPnrAsync(string pnr);

    }
}
