using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Entities
{
    public class Banner
    {
        [Key]
        public int BannerID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
