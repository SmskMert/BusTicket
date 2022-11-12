using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTicket.Core
{
    public static class Jobs
    {
        public static string UpdateDateFormat(string Date)
        {
            var dateArray = Date.Split("-");
            var day = dateArray[2];
            var month = dateArray[1];
            var year = dateArray[0];
            return day + "." + month + "." + year;
        }
    }
}
