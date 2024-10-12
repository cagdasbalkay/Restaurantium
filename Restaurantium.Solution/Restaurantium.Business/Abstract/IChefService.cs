using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Abstract
{
    public interface IChefService : IGenericService<Chef>
    {
        public Task<List<Chef>> Get4ChefsAsync();

    }
}
