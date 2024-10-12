using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Abstract
{
    public interface IService : IGenericService<Service>
    {
        public Task<List<Service>> GetLast4ServicesAsync();
    }
}
