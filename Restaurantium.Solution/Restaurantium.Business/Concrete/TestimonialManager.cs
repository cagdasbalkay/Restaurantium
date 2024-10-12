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
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _testimonialDal;

        public TestimonialManager(ITestimonialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public async Task Create(Testimonial entity)
        {
            await _testimonialDal.Create(entity);
        }

        public async Task Delete(Testimonial entity)
        {
            await _testimonialDal.Delete(entity);

        }

        public async Task<List<Testimonial>> GetAll()
        {
           return await _testimonialDal.GetAll();
        }

        public async Task<Testimonial> GetById(int id)
        {
            var value = await _testimonialDal.GetById(id);
            return value;
        }

        public async Task Update(Testimonial entity)
        {
            await _testimonialDal.Update(entity);
        }
    }
}
