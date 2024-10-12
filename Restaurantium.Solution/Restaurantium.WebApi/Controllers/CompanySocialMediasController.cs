using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.BookingValidators;
using Restaurantium.Business.ValidationRules.CompanySocialMediaValidators;
using Restaurantium.DataAccess.Entities;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanySocialMediasController : ControllerBase
    {
        CompanySocialMediaManager _companySocialMediaManager;
        CompanySocialMediaValidator _companySocialMediaValidator;

        public CompanySocialMediasController(CompanySocialMediaManager companySocialMediaManager, CompanySocialMediaValidator companySocialMediaValidator)
        {
            _companySocialMediaManager = companySocialMediaManager;
            _companySocialMediaValidator = companySocialMediaValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCompanySocialMediaAccounts()
        {
           var values = await _companySocialMediaManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetCompanySocialMediaById")]
        public async Task<IActionResult> GetCompanySocialMediaById(int id)
        {
            var values = await _companySocialMediaManager.GetById(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCompanySocialMedia(CompanySocialMedia CompanySocialMedia)
        {
            var validationResult = await _companySocialMediaValidator.ValidateAsync(CompanySocialMedia);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _companySocialMediaManager.Create(CompanySocialMedia);
            return Ok("Başarıyla oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCompanySocialMedia(CompanySocialMedia CompanySocialMedia)
        {
            var validationResult = await _companySocialMediaValidator.ValidateAsync(CompanySocialMedia);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _companySocialMediaManager.Update(CompanySocialMedia);
            return Ok("Başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCompanySocialMedia(int id)
        {
            var value = await _companySocialMediaManager.GetById(id);
            await _companySocialMediaManager.Delete(value);
            return Ok("Başarıyla silindi");
        }
    }
}
