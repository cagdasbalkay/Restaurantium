using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.ViewModels
{
    public class FooterViewModel
    {
        public FooterContact FooterContact { get; set; }
        public WorkingHour WorkingHour { get; set; }
        public CompanySocialMedia CompanySocialMedia { get; set; }
    }
}
