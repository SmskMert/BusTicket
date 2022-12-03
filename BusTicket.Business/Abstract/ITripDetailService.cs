using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Abstract
{
    public interface ITripDetailService
    {
        Task<List<TripDetail>> GetAllAsync();

        Task<TripDetail> GetByIdAsync(int id);

        Task CreateAsync(TripDetail tripDetail);

        Task UpdateAsync(TripDetail tripDetail);

        Task DeleteAsync(TripDetail tripDetail);
    }
}
