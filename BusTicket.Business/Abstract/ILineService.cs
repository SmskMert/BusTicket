using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Abstract
{
    public interface ILineService
    {
        Task<List<Line>> GetAllAsync();

        Task<Line> GetByIdAsync(int id);

        Task CreateAsync(Line line);

        Task UpdateAsync(Line line);

        Task DeleteAsync(Line line);
    }
}
