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
    public class BannerManager : IBannerService
    {
        private readonly IBannerDal _bannerDal;

        public BannerManager(IBannerDal bannerDal)
        {
            _bannerDal = bannerDal;
        }

        public async Task Create(Banner entity)
        {
            await _bannerDal.Create(entity);
        }

        public async Task Delete(Banner entity)
        {
            await _bannerDal.Delete(entity);
        }

        public async Task<List<Banner>> GetAll()
        {
            return await _bannerDal.GetAll();
        }

        public async Task<Banner> GetById(int id)
        {
            var value = await _bannerDal.GetById(id);
            return value;
        }

        public async Task Update(Banner entity)
        {
            await _bannerDal.Update(entity);
        }
    }
}
