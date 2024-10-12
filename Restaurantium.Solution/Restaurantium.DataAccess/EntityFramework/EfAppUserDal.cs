using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories.AppUserRepositories;
using Restaurantium.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.EntityFramework
{
    public class EfAppUserDal : AppUserRepository, IAppUserDal
    {
        public EfAppUserDal(RestaurantiumContext context) : base(context)
        {
        }
    }
}
