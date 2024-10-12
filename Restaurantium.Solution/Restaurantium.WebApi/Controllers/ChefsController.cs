using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.ChefValidators;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.ChefDtos;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ChefManager _chefManager;
        private readonly ChefValidator _chefValidator;

        public ChefsController(ChefManager chefManager, ChefValidator chefValidator)
        {
            _chefManager = chefManager;
            _chefValidator = chefValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllChefs()
        {
            var values = await  _chefManager.GetAll();
            return Ok(values);
        }
        [HttpGet("Get4Chefs")]

        public async Task<IActionResult> Get4ChefsAsync()
        {
            var values = await _chefManager.Get4ChefsAsync();
            return Ok(values);
        }

        [HttpGet("GetChefById")]
        public async Task<IActionResult> GetChefById(int id)
        {
            var values = await _chefManager.GetById(id);
            return Ok(values);
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateChef(Chef chef)
        {
            var validationResult = await _chefValidator.ValidateAsync(chef);
            if(!validationResult.IsValid)
            {
                BadRequest(validationResult.Errors);
            }
            await _chefManager.Create(chef);
            return Ok("Başarıyla oluşturuldu");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateChef(Chef chef)
        {
            var validationResult = await _chefValidator.ValidateAsync(chef);
            if (!validationResult.IsValid)
            {
                BadRequest(validationResult.Errors);
            }
            await _chefManager.Update(chef);
            return Ok("Başarıyla güncellendi");
        }

        [Authorize(Roles = "Admin")]

        [HttpDelete]
        public async Task<IActionResult> RemoveChef(int id)
        {
            var value = await _chefManager.GetById(id);
            await _chefManager.Delete(value);
            return Ok("Başarıyla silindi");
        }


    }
}
