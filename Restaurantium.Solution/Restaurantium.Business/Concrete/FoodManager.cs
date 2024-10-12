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
    public class FoodManager : IFoodService
    {
        private readonly IFoodDal _dal;

        public FoodManager(IFoodDal dal)
        {
            _dal = dal;
        }

        public async Task Create(Food entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(Food entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<List<Food>> GetAll()
        {
            return await _dal.GetAll();
        }

        public async Task<Food> GetById(int id)
        {
            var value = await _dal.GetById(id);
            return value;

        }

        public async Task Update(Food entity)
        {
            await _dal.Update(entity);
        }
    }
}
