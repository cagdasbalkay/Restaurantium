using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories.StatisticRepositories;
using Restaurantium.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.EntityFramework
{
    public class EfStatisticDal : StatisticRepository, IStatisticDal
    {
        public EfStatisticDal(RestaurantiumContext restaurantiumContext) : base(restaurantiumContext)
        {
        }
    }
}
