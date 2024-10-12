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
    public class EfProfileDal : ProfileRepository, IProfileDal
    {
        public EfProfileDal(RestaurantiumContext context) : base(context)
        {
        }
    }
}
