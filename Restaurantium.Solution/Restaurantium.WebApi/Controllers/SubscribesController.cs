using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.SubscribeValidator;
using Restaurantium.DataAccess.Entities;
using Restaurantium.DataAccess.ViewModels;
using Restaurantium.Dto.SubscribeDtos;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribesController : ControllerBase
    {
        private readonly SubscribeManager _subscribeManager;
        private readonly CreateSubscribeValidator _createSubscribeValidator;
        private readonly UpdateSubscribeValidator _updateSubscribeValidator;

        public SubscribesController(SubscribeManager subscribeManager, CreateSubscribeValidator createSubscribeValidator, UpdateSubscribeValidator updateSubscribeValidator)
        {
            _subscribeManager = subscribeManager;
            _createSubscribeValidator = createSubscribeValidator;
            _updateSubscribeValidator = updateSubscribeValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubscribes()
        {
            var values = await _subscribeManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetSubscribeById")]
        public async Task<IActionResult> GetSubscribeById(int id)
        {
            var value = await _subscribeManager.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSubscribe(CreateSubscribeDto createSubscribeDto)
        {
            var result = await _createSubscribeValidator.ValidateAsync(createSubscribeDto);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _subscribeManager.Create(new Subscribe
            {
                Email = createSubscribeDto.Email
            });
            return Ok("Başarıyla Oluşturuldu");

        }

        [HttpPut]
        public async Task<IActionResult> UpdateSubscribe(Subscribe Subscribe)
        {
            var result = await _updateSubscribeValidator.ValidateAsync(Subscribe);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _subscribeManager.Update(Subscribe);
            return Ok("Başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveSubscribe(int id)
        {
            var value = await _subscribeManager.GetById(id);
            await _subscribeManager.Delete(value);
            return Ok("Başarıyla silindi");
        }
    }
}
