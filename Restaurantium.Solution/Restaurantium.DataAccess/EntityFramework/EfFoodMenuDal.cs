using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories.FoodRepositories;
using Restaurantium.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.EntityFramework
{
    public class EfFoodMenuDal : FoodMenuRepository, IFoodMenuDal
    {
        public EfFoodMenuDal(RestaurantiumContext context) : base(context)
        {
        }
    }
}
