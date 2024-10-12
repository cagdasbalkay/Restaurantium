using Restaurantium.Business.Abstract;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.Concrete
{
    public class ServiceManager : IService
    {
        private readonly IServiceDal _serviceDal;

        public ServiceManager(IServiceDal serviceDal)
        {
            _serviceDal = serviceDal;
        }

        public async Task Create(Service entity)
        {
            await _serviceDal.Create(entity);
        }

        public async Task Delete(Service entity)
        {
            await _serviceDal.Delete(entity);

        }

        public async Task<List<Service>> GetAll()
        {
           return await _serviceDal.GetAll();
        }

        public async Task<Service> GetById(int id)
        {
            var value = await _serviceDal.GetById(id);
            return value;
        }

        public async Task<List<Service>> GetLast4ServicesAsync()
        {
           var values = await _serviceDal.GetLast4ServicesAsync();
            return values;
        }

        public async Task Update(Service entity)
        {
            await _serviceDal.Update(entity);
        }
    }
}
