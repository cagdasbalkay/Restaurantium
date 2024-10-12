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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public async Task Create(Contact entity)
        {
            await _contactDal.Create(entity);
        }

        public async Task Delete(Contact entity)
        {
            await _contactDal.Delete(entity);
        }

        public async Task<List<Contact>> GetAll()
        {
            var values = await _contactDal.GetAll();
            return values;
        }

        public Task<Contact> GetById(int id)
        {
            var value = _contactDal.GetById(id);
            return value;
        }

        public List<Contact> GetLast5ContactMessages()
        {
            var values = _contactDal.GetLast5ContactMessages();
            return values;
        }

        public async Task Update(Contact entity)
        {
            await _contactDal.Update(entity);
        }
    }
}
