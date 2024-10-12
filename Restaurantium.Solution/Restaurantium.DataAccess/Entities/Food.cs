using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Entities
{
    public class Food
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
