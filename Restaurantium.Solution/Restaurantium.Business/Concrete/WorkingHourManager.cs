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
    public class WorkingHourManager : IWorkingHourService
    {
        private readonly IWorkingHourDal _dal;

        public WorkingHourManager(IWorkingHourDal dal)
        {
            _dal = dal;
        }

        public async Task Create(WorkingHour entity)
        {
            await _dal.Create(entity);
        }

        public async Task Delete(WorkingHour entity)
        {
            await _dal.Delete(entity);
        }

        public async Task<List<WorkingHour>> GetAll()
        {
            return await _dal.GetAll();
        }

        public async Task<WorkingHour> GetById(int id)
        {
            var value = await _dal.GetById(id);
            return value;

        }

        public async Task Update(WorkingHour entity)
        {
            await _dal.Update(entity);
        }
    }
}
