using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.ViewModels
{
    public class ResultCompanySocialMediaViewModel
    {
        public int CompanySocialMediaID { get; set; }
        public string Platform { get; set; }
        public string Url { get; set; }
        public string IconClass { get; set; }
    }
}
