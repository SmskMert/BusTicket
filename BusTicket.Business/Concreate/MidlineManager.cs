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
    public class MidlineManager : IMidlineService
    {
        private readonly IMidlineRepository _midlineRepository;

        public MidlineManager(IMidlineRepository midlineRepository)
        {
            _midlineRepository = midlineRepository;
        }

        public async Task CreateAsync(MidLine midLine)
        {
            await _midlineRepository.CreateAsync(midLine);
        }

        public async Task DeleteAsync(MidLine midLine)
        {
            await _midlineRepository.DeleteAsync(midLine);
        }

        public async Task<List<MidLine>> GetAllAsync()
        {
            return await _midlineRepository.GetAllAsync();
        }

        public async Task<MidLine> GetByIdAsync(int id)
        {
            return await _midlineRepository.GetByIdAsync(id);
        }

        public async Task UpdateAsync(MidLine midLine)
        {
           await _midlineRepository.UpdateAsync(midLine);
        }
    }
}
