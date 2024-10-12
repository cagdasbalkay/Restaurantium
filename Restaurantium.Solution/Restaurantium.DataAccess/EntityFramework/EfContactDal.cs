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
    public class EfContactDal : GenericRepository<Contact>, IContactDal
    {
        private readonly RestaurantiumContext _context;
        public EfContactDal(RestaurantiumContext context) : base(context)
        {
            _context = context;
        }

        public List<Contact> GetLast5ContactMessages()
        {
            var values = _context.Contacts.OrderByDescending(x => x.ContactID).Take(5).ToList();
            return values;
        }
    }
}
