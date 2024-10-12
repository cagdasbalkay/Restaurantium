using Restaurantium.Business.Abstract;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Entities;
using Restaurantium.DataAccess.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Concrete
{
    public class SubscribeManager : ISubscribeService
    {
        private readonly ISubscribeDal _subscribeDal;

        public SubscribeManager(ISubscribeDal subscribeDal)
        {
            _subscribeDal = subscribeDal;
        }

        public async Task Create(Subscribe entity)
        {
            await _subscribeDal.Create(entity);
        }

        public async Task Delete(Subscribe entity)
        {
            await _subscribeDal.Delete(entity);
        }

        public async Task<List<Subscribe>> GetAll()
        {
            var values = await _subscribeDal.GetAll();
            return values;
        }

        public async Task<Subscribe> GetById(int id)
        {
            var value = await _subscribeDal.GetById(id);
            return value;
        }

        public async Task Update(Subscribe entity)
        {
            await _subscribeDal.Update(entity);

        }
    }
}
