using BusTicket.Business.Abstract;
using BusTicket.Data.Abstract;
using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Concreate
{
    public class TicketManager : ITicketService
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketManager(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }

        public async Task CreateAsync(Ticket ticket)
        {
            await _ticketRepository.CreateAsync(ticket);
        }

        public async Task DeleteAsync(Ticket ticket)
        {
            await _ticketRepository.DeleteAsync(ticket);
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
            return await _ticketRepository.GetAllAsync();
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
            return await _ticketRepository.GetByIdAsync(id);
        }

        public async Task<Ticket> GetTicketWithTrip(int id)
        {
            return await _ticketRepository.GetTicketWithTrip(id);
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            await _ticketRepository.UpdateAsync(ticket);
        }
    }
}
