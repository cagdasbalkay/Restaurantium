using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;
using Restaurantium.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.EntityFramework
{
    public class EfSubscribeDal : GenericRepository<Subscribe>, ISubscribeDal
    {
       
        public EfSubscribeDal(RestaurantiumContext context) : base(context)
        {
        }
       

    }
}
