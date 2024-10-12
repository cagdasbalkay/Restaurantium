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
    public class EfCompanySocialMediaDal : GenericRepository<CompanySocialMedia>, ICompanySocialMediaDal
    {
        public EfCompanySocialMediaDal(RestaurantiumContext context) : base(context)
        {
        }
    }
}
