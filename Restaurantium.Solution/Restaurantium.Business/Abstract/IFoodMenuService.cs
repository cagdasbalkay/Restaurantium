using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Abstract
{
    public interface IFoodMenuService
    {
        public List<Food> GetFoodsByCategoryId(int categoryId);
        public List<Food> Get8FoodsPerCategory(int categoryId);

    }
}
