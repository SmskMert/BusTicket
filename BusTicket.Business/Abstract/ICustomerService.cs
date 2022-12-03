using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Business.Abstract
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllAsync();

        Task<Customer> GetByIdAsync(int id);

        Task CreateAsync(Customer customer);

        Task UpdateAsync(Customer customer);

        Task DeleteAsync(Customer customer);
        Task<Customer> GetCustomerByUserNameAsync(string userName);
    }
}
