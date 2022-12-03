using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Abstract
{
    public interface IBusService
    {
        Task<List<Bus>> GetAllAsync();

        Task<Bus> GetByIdAsync(int id);

        Task CreateAsync(Bus Bus);

        Task UpdateAsync(Bus Bus);

        Task DeleteAsync(Bus Bus);
    }
}
