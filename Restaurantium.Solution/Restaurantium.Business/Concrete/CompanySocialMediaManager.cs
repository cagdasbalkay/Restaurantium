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
    public class CompanySocialMediaManager : ICompanySocialMediaService
    {
        private readonly ICompanySocialMediaDal _companySocialMediaDal;

        public CompanySocialMediaManager(ICompanySocialMediaDal companySocialMediaDal)
        {
            _companySocialMediaDal = companySocialMediaDal;
        }

        public async Task Create(CompanySocialMedia entity)
        {
            await _companySocialMediaDal.Create(entity);
        }

        public async Task Delete(CompanySocialMedia entity)
        {
            await _companySocialMediaDal.Delete(entity);
        }

        public async Task<List<CompanySocialMedia>> GetAll()
        {
            var values = await _companySocialMediaDal.GetAll();
            return values;
        }

        public async Task<CompanySocialMedia> GetById(int id)
        {
            var value = await _companySocialMediaDal.GetById(id);
            return value;
        }

        public async Task Update(CompanySocialMedia entity)
        {
            await _companySocialMediaDal.Update(entity);

        }
    }
}
