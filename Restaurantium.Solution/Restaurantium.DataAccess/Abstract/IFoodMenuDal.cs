using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Abstract
{
    public interface IFoodMenuDal
    {
        public List<Food> GetFoodsByCategoryId(int categoryId);
        public List<Food> Get8FoodsPerCategory(int categoryId);

    }
}
