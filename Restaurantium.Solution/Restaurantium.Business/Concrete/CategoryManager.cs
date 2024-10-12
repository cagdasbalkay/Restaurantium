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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _dal;

        public CategoryManager(ICategoryDal dal)
        {
            _dal = dal;
        }

        public async Task Create(Category entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(Category entity)
        {
            await _dal.Delete(entity);

        }

        public async Task<List<Category>> GetAll()
        {
            var values = await _dal.GetAll();
            return values;
        }

        public async Task<Category> GetById(int id)
        {
            var value = await _dal.GetById(id);
            return value;
        }

        public async Task Update(Category entity)
        {
            await _dal.Update(entity);
        }
    }
}
