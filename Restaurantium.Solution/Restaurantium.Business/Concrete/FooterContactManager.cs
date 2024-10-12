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
    public class FooterContactManager : IFooterContactService
    {
        private readonly IFooterContactDal _dal;

        public FooterContactManager(IFooterContactDal dal)
        {
            _dal = dal;
        }

        public async Task Create(FooterContact entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(FooterContact entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<List<FooterContact>> GetAll()
        {
            return await _dal.GetAll();
        }

        public async Task<FooterContact> GetById(int id)
        {
            var value = await _dal.GetById(id);
            return value;

        }

        public async Task Update(FooterContact entity)
        {
            await _dal.Update(entity);
        }
    }
}
