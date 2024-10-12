using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Concrete
{
    public class FoodMenuManager : IFoodMenuDal
    {
        private readonly IFoodMenuDal _foodMenuDal;

        public FoodMenuManager(IFoodMenuDal foodMenuDal)
        {
            _foodMenuDal = foodMenuDal;
        }


        public List<Food> GetFoodsByCategoryId(int categoryId)
        {
            var values = _foodMenuDal.GetFoodsByCategoryId(categoryId);
            return values;
        }


        public List<Food> Get8FoodsPerCategory(int categoryId)
        {
            var values = _foodMenuDal.Get8FoodsPerCategory(categoryId);
            return values;
        }
    }
}
