using Restaurantium.Business.Abstract;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Entities;


namespace Restaurantium.Business.Concrete
{
    public class ChefManager : IChefService
    {
        private readonly IChefDal _chefDal;

        public ChefManager(IChefDal chefDal)
        {
            _chefDal = chefDal;
        }

        public async Task Create(Chef entity)
        {
            await _chefDal.Create(entity);
        }

        public async Task Delete(Chef entity)
        {
            await _chefDal.Delete(entity);

        }



        public async Task<List<Chef>> GetAll()
        {
            var values = await _chefDal.GetAll();
            return values;

        }

        public async Task<Chef> GetById(int id)
        {
            var value = await _chefDal.GetById(id);
            return value;

        }

       

        public async Task Update(Chef entity)
        {
           await _chefDal.Update(entity);
        }

        public async Task<List<Chef>> Get4ChefsAsync()
        {
            var values = await _chefDal.Get4ChefsAsync();
            return values;
        }
    }
}
