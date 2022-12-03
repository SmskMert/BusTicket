using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Abstract
{
    public interface ILineRepository : IRepository<Line>
    {
        Task<List<Line>> GetLinesBySearchAsync(string from, string to);
        Task<List<Line>> GetLinesWithTripsAsync();
        Task<Line> GetLineWithDetailsAsync(int id);
    }
}
