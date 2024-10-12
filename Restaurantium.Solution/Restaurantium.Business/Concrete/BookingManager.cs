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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _bookingDal;

        public BookingManager(IBookingDal bookingDal)
        {
            _bookingDal = bookingDal;
        }

        public async Task Create(Booking entity)
        {
            await _bookingDal.Create(entity);
        }

        public async Task Delete(Booking entity)
        {
            await _bookingDal.Delete(entity);
        }

        public async Task<List<Booking>> GetAll()
        {
            var values = await _bookingDal.GetAll();
            return values;
        }

        public async Task<Booking> GetById(int id)
        {
            var value = await _bookingDal.GetById(id);
            return value;
        }

        public async Task Update(Booking entity)
        {
            await _bookingDal.Update(entity);
        }
    }
}
