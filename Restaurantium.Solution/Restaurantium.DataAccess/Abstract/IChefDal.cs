using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.DataAccess.Abstract
{
    public interface IChefDal : IGenericDal<Chef>
    {
        public Task<List<Chef>> Get4ChefsAsync();
    }
}
