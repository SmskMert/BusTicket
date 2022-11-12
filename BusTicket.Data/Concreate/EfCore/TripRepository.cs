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
    public class TripRepository : GenericRepository<Trip>, ITripRepository
    {
        public TripRepository(Context_BusTicket context) : base(context)
        {
        }
        private Context_BusTicket Context
        {
            get { return _context as Context_BusTicket; }
        }

        public async Task<List<Trip>> GetAllTripsWDetails()
        {
           var trips = await Context.Trips
                .Include(e=>e.TripDetail)
                .Include(e=>e.MidLine)
                .ToListAsync();
            return trips;
        }

        public async Task<List<Trip>> GetTripsBySearch(string origin, string destination, string date)
        {
            var tripsFromOriginOrToDestination = await Context.Trips.Where(e=>e.ScheduleDate == date)
                .Include(e => e.MidLine)
                .ThenInclude(e=>e.Line)
                .ThenInclude(e =>e.MidLines)
                .Where(e=> e.MidLine.Destination == destination || e.MidLine.StartingPoint == origin)
                .Include(e=>e.TripDetail)
                .ThenInclude(e=>e.Bus).ToListAsync();

            //var Line
            //foreach (var trip in tripsFromOriginOrToDestination)
            //{
            //    trip.MidLine.Line.MidLines
            //}

            return tripsFromOriginOrToDestination;

        }

        public async Task<Trip> GetTripWithDetails(int id)
        {
            return await Context.Trips.Where(e => e.Id == id)
                .Include(e => e.Tickets)
                .Include(e=> e.MidLine)
                .Include(e => e.TripDetail)
                .Include(e => e.TripDetail.Bus)
                .Include(e => e.TripDetail.Company)
                .Include(e => e.TripDetail.Driver)
                .FirstOrDefaultAsync();
        }



    }
}
