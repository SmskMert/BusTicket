using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTicket.Entity;

namespace BusTicket.Business.Abstract
{
    public interface ITripService
    {
        Task<List<Trip>> GetAllAsync();

        Task<Trip> GetByIdAsync(int id);

        Task CreateAsync(Trip entity);

        Task UpdateAsync(Trip entity);

        Task DeleteAsync(Trip entity);

        Task<List<Trip>> GetAllTripsWDetails();

        Task<List<Trip>> GetTripsBySearch(string origin, string destination, string date);

        Task<Trip> GetTripWithDetails(int id);
        Task<List<Trip>> GetTripsBySearchAndLine(string origin, string destination, string date, int lineId);
    }
}
