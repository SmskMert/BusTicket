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
    public class TripManager : ITripService
    {
        private readonly ITripRepository _tripRepository;

        public TripManager(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }

        public async Task CreateAsync(Trip entity)
        {
           await _tripRepository.CreateAsync(entity);
        }

        public async Task DeleteAsync(Trip entity)
        {
            await _tripRepository.DeleteAsync(entity);
        }

        public async Task<List<Trip>> GetAllAsync()
        {
           return await _tripRepository.GetAllAsync();
        }

        public async Task<List<Trip>> GetAllTripsWDetails()
        {
            return await _tripRepository.GetAllTripsWDetails();
        }

        public async Task<Trip> GetByIdAsync(int id)
        {
           return await _tripRepository.GetByIdAsync(id);
        }
        public async Task UpdateAsync(Trip entity)
        {
            await _tripRepository.UpdateAsync(entity);
        }

        public async Task<List<Trip>> GetTripsBySearch(string origin, string destination, string date)
        {
            return await _tripRepository.GetTripsBySearch(origin, destination, date);
        }

        public async Task<Trip> GetTripWithDetails(int id)
        {
            return await _tripRepository.GetTripWithDetails(id);
        }

        public async Task<List<Trip>> GetTripsBySearchAndLine(string origin, string destination, string date, int lineId)
        {
            return await _tripRepository.GetTripsBySearchAndLine(origin, destination, date, lineId);

        }
    }
}
