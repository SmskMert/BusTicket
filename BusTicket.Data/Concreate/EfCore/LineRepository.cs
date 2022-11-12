using BusTicket.Data.Abstract;
using BusTicket.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Data.Concreate.EfCore
{
    public class LineRepository : GenericRepository<Line>, ILineRepository 
    {
        public LineRepository(Context_BusTicket busTicket) : base(busTicket)
        {
        }
        private Context_BusTicket Context
        {
            get { return _context as Context_BusTicket; }
        }
    }
}
