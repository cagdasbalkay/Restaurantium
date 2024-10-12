using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.BookingValidators;
using Restaurantium.DataAccess.Entities;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingManager _bookingManager;
        private readonly BookingValidator _bookingValidator;

        public BookingsController(BookingManager bookingManager, BookingValidator bookingValidator)
        {
            _bookingManager = bookingManager;
            _bookingValidator = bookingValidator;
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task <IActionResult> GetAllBookings()
        {
            var values = await _bookingManager.GetAll();
            return Ok(values);
        }
        [Authorize(Roles = "Admin")]

        [HttpGet("GetBookingById")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var values = await _bookingManager.GetById(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
          await _bookingManager.Create(booking);
            return Ok("Rezervasyon Oluşturuldu");
        }
        [Authorize(Roles = "Admin")]

        [HttpPut]
        public async Task<IActionResult> UpdateBooking(Booking Booking)
        {
           var validationResult = await _bookingValidator.ValidateAsync(Booking);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _bookingManager.Update(Booking);
            return Ok("Başarıyla güncellendi");
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> RemoveBooking(int id)
        {
            var value = await _bookingManager.GetById(id);
            await _bookingManager.Delete(value);
            return Ok("Başarıyla silindi");
        }
    }
}
