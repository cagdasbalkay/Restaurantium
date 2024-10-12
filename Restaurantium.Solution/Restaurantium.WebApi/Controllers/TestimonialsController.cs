using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.TestimonialValidators;
using Restaurantium.DataAccess.Entities;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {

        private readonly TestimonialManager _testimonialManager;
        private readonly TestimonialValidator _testimonialValidator;

        public TestimonialsController(TestimonialManager testimonialManager, TestimonialValidator testimonialValidator)
        {
            _testimonialManager = testimonialManager;
            _testimonialValidator = testimonialValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTestimonials()
        {
            var values = await _testimonialManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetTestimonialById")]
        public async Task<IActionResult> GetTestimonialById(int id)
        {
            var value = await _testimonialManager.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(Testimonial Testimonial)
        {
            var result = await _testimonialValidator.ValidateAsync(Testimonial);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _testimonialManager.Create(Testimonial);
            return Ok("Testimonial alanı başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTestimonial(Testimonial Testimonial)
        {
            var result = await _testimonialValidator.ValidateAsync(Testimonial);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _testimonialManager.Update(Testimonial);
            return Ok("Testimonial alanı başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveTestimonial(int id)
        {
            var value = await _testimonialManager.GetById(id);
            await _testimonialManager.Delete(value);
            return Ok("Testimonial alanı başarıyla silindi");
        }
    }
}
