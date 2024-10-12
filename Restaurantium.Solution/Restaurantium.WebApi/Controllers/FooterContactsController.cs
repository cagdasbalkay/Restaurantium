using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.FooterContactValidators;
using Restaurantium.DataAccess.Entities;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FooterContactsController(FooterContactManager FooterContactManager, FooterContactValidator footerContactValidator) : ControllerBase
    {
        private readonly FooterContactManager _FooterContactManager = FooterContactManager;
        private readonly FooterContactValidator _footerContactValidator = footerContactValidator;

        [HttpGet]
        public async Task<IActionResult> GetFooterContacts()
        {
            var values = await _FooterContactManager.GetAll();
            return Ok(values);
        }
        [HttpGet("GetFooterContactById")]
        public async Task<IActionResult> GetFooterContactById(int id)
        {
            var values = await _FooterContactManager.GetById(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFooterContact(FooterContact FooterContact)
        {
            var result = await _footerContactValidator.ValidateAsync(FooterContact);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _FooterContactManager.Create(FooterContact);
            return Ok("Başarıyla oluşturuldu");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateFooterContact(FooterContact FooterContact)
        {
            var result = await _footerContactValidator.ValidateAsync(FooterContact);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _FooterContactManager.Update(FooterContact);
            return Ok("Başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFooterContact(int id)
        {
            var value = await _FooterContactManager.GetById(id);
            await _FooterContactManager.Delete(value);
            return Ok("Başarıyla silindi");
        }
    }
}
