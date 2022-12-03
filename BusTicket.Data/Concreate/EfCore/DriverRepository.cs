using BusTicket.Data.Abstract;
using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Concreate.EfCore
{
    public class DriverRepository : GenericRepository<Driver> , IDriverRepository
    {
        public Context_BusTicket Context { get
            {
                return _context as Context_BusTicket;
            } 
        }
        public DriverRepository(Context_BusTicket Context) : base(Context)
        {
        }



    }
}
