using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.EntityFramework
{
    public class EfWorkingHourDal : GenericRepository<WorkingHour>, IWorkingHourDal
    {
        public EfWorkingHourDal(RestaurantiumContext context) : base(context)
        {
        }
    }
}
