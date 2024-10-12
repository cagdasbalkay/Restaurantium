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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _dal;

        public AboutManager(IAboutDal dal)
        {
            _dal = dal;
        }

        public async Task Create(About entity)
        {
           await _dal.Create(entity);
        }

        public async Task Delete(About entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<List<About>> GetAll()
        {
            return await _dal.GetAll();
        }

        public async Task<About> GetById(int id)
        {
            var value = await _dal.GetById(id);
            return value;

        }

        public async Task Update(About entity)
        {
            await _dal.Update(entity);
        }
    }
}
