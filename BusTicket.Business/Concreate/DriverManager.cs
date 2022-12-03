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
    public class DriverManager : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        public DriverManager(IDriverRepository driverRepository)
        {
            _driverRepository = driverRepository;
        }


        public async Task CreateAsync(Driver Driver)
        {
           await _driverRepository.CreateAsync(Driver);
        }

        public async Task DeleteAsync(Driver Driver)
        {
            await _driverRepository.DeleteAsync(Driver);
        }

        public async Task<List<Driver>> GetAllAsync()
        {
           return await _driverRepository.GetAllAsync();
        }

        public async Task<Driver> GetByIdAsync(int id)
        {
            return await (_driverRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(Driver Driver)
        {
            await _driverRepository.UpdateAsync(Driver);
        }
    }
}
