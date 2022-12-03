using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Abstract
{
    public interface IDriverService
    {
        Task<List<Driver>> GetAllAsync();

        Task<Driver> GetByIdAsync(int id);

        Task CreateAsync(Driver driver);

        Task UpdateAsync(Driver driver);

        Task DeleteAsync(Driver driver);
    }
}
