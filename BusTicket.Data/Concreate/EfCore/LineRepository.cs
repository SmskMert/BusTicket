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
    public class LineRepository : GenericRepository<Line>, ILineRepository
    {
        public LineRepository(Context_BusTicket busTicket) : base(busTicket)
        {
        }
        private Context_BusTicket Context
        {
            get { return _context as Context_BusTicket; }
        }

        public async Task<List<Line>> GetLinesBySearchAsync(string from, string to)
        {
            var filteredLines = await Context
               .Lines
               .Include(line => line.MidLines)
               .Where(line => line.MidLines.Any(midLine => midLine.StartingPoint == from))
               .Where(line => line.MidLines.Any(midLine => midLine.Destination == to))
               .ToListAsync();

            //var Lines = await Context.Lines
            //     .Include(e => e.MidLines).ToListAsync();

            //var filteredLines = new List<Line>();
            //foreach (var line in Lines)
            //{
            //    Line lineToBeAddedToList = null;

            //    foreach (var midLine in line.MidLines)
            //    {
            //        if (midLine.StartingPoint == from)
            //        {
            //            lineToBeAddedToList = line;
            //        }
            //        if (midLine.Destination == to)
            //        {
            //            if (lineToBeAddedToList == line)
            //            {
            //                filteredLines.Add(lineToBeAddedToList);
            //                break;
            //            }
            //        }
            //    }
            //}

            return filteredLines;
        }

        public async Task<List<Line>> GetLinesWithTripsAsync()
        {
            var linesWithTrips = await Context
               .Lines
               .Include(line => line.MidLines)
               .ThenInclude(ml => ml.Trips)
               .ThenInclude(t => t.TripDetail)
               .ToListAsync();
           
            return linesWithTrips;
        }

        public async Task<Line> GetLineWithDetailsAsync(int id)
        {
            var line = await Context
               .Lines.Where(line => line.Id == id)
               .Include(line => line.MidLines)
               .ThenInclude(ml => ml.Trips)
               .ThenInclude(t => t.TripDetail)
               .ThenInclude(td => td.Bus)
               .Include(line => line.MidLines)
               .ThenInclude(ml => ml.Trips)
               .ThenInclude(t => t.TripDetail)
               .ThenInclude(td => td.Driver)
               .FirstOrDefaultAsync();

            return line;
        }
    }

}
