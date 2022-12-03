using BusTicket.Data.Abstract;
using BusTicket.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Concreate.EfCore
{
    public class CustomerRepository: GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context_BusTicket busTicket) : base(busTicket)
        {
        }

        public Context_BusTicket Context {
            get
            {
                return _context as Context_BusTicket;
            }
        }

        public async Task<Customer> GetCustomerByUserNameAsync(string userName)
        {
            var customer = await Context.Customers.Where(e => e.UserName == userName).FirstOrDefaultAsync();

            return customer;
        }

    }
}
