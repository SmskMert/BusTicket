using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Abstract
{
    public interface IMidlineService
    {
        Task<List<MidLine>> GetAllAsync();

        Task<MidLine> GetByIdAsync(int id);

        Task CreateAsync(MidLine midLine);

        Task UpdateAsync(MidLine midLine);

        Task DeleteAsync(MidLine midLine);
    }
}
