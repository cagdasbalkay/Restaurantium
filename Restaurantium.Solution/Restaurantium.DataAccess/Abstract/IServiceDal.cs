using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Abstract
{
    public interface IServiceDal : IGenericDal<Service>
    {
        public  Task<List<Service>> GetLast4ServicesAsync();
    }
}
