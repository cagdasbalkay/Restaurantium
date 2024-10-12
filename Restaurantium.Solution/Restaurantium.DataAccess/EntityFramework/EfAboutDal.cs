using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Concrete.Repositories;
using Restaurantium.DataAccess.Context;
using Restaurantium.DataAccess.Entities;

namespace Restaurantium.DataAccess.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
        public EfAboutDal(RestaurantiumContext context) : base(context)
        {
        }
    }
}
