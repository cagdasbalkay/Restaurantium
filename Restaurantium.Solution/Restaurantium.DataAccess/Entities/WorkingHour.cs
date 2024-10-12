using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Entities
{
    public class WorkingHour
    {
        public int WorkingHourID { get; set; }
        public string WeekDayWorkingHours { get; set; }
        public string WeekendWorkingHours { get; set; }
    }
}
