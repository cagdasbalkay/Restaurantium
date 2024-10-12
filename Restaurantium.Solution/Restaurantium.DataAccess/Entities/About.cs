using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Entities
{
    public class About
    {
        [Key]
        public int AboutID { get; set; }
        public string Description { get; set; }
        public byte YearsOfExperience { get; set; }
        public string Image1Url { get; set; }
        public string Image2Url { get; set; }
        public string Image3Url { get; set; }
        public string Image4Url { get; set; }

    }
}
