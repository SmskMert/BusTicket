using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Abstract
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<Customer> GetCustomerByUserNameAsync(string userName);
    }
}
