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
    public class BusManager : IBusService
    {
        private readonly IBusRepository _busRepository;
        public BusManager(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }


        public async Task CreateAsync(Bus Bus)
        {
           await _busRepository.CreateAsync(Bus);
        }

        public async Task DeleteAsync(Bus Bus)
        {
            await _busRepository.DeleteAsync(Bus);
        }

        public async Task<List<Bus>> GetAllAsync()
        {
           return await _busRepository.GetAllAsync();
        }

        public async Task<Bus> GetByIdAsync(int id)
        {
            return await (_busRepository.GetByIdAsync(id));
        }

        public async Task UpdateAsync(Bus Bus)
        {
            await _busRepository.UpdateAsync(Bus);
        }
    }
}
