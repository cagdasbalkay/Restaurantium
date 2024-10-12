using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.AboutValidatators;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.AboutDtos;

namespace Restaurantium.WebApi.Controllers
{
    //[AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController(AboutManager aboutManager, CreateAboutValidator createAboutvalidator, UpdateAboutValidator updateAboutValidator) : ControllerBase
    {
        private readonly AboutManager _aboutManager = aboutManager;
        private readonly CreateAboutValidator _createAboutvalidator = createAboutvalidator;
        private readonly UpdateAboutValidator _updateAboutValidator = updateAboutValidator;

        [HttpGet]
        public async Task<IActionResult> GetAbouts()
        {
            var values = await _aboutManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetAboutById")]
        public async Task<IActionResult> GetAboutById(int id)
        {
            var value = await _aboutManager.GetById(id);
            return Ok(value);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto dto)
        {
            var validationResult = _createAboutvalidator.Validate(dto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _aboutManager.Create(new About
            {
                Description = dto.Description,
                Image1Url = dto.Image1Url,
                Image2Url = dto.Image2Url,
                Image3Url = dto.Image3Url,
                Image4Url = dto.Image4Url,
                YearsOfExperience = dto.YearsOfExperience
            });
            return Ok("About alanı başarıyla oluşturuldu");
        }
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateAbout(About about)
        {
            var validationResult = await _updateAboutValidator.ValidateAsync(about);
            if (validationResult.IsValid)
            {
                await _aboutManager.Update(about);
                return Ok("About alanı başarıyla güncellendi");
            }
            return BadRequest(validationResult.Errors);
            
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete]
        public async Task<IActionResult> RemoveAbout(int id)
        {
            var value = await _aboutManager.GetById(id);
            await _aboutManager.Delete(value);
            return Ok("About alanı başarıyla silindi");
        }
    }
}
