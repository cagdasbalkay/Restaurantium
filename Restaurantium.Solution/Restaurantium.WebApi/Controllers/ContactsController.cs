using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.ContactValidators;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.ContactDtos;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactManager _contactManager;
        private readonly ContactValidator _contactValidator;

        public ContactsController(ContactManager contactManager, ContactValidator contactValidator)
        {
            _contactManager = contactManager;
            _contactValidator  = contactValidator;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var values = await _contactManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetContactById")]
        public async Task<IActionResult> GetContactById(int id)
        {
            var value = await _contactManager.GetById(id);
            return Ok(value);
        }

        
        [HttpGet("GetLast5ContactMessages")]
        public IActionResult GetLast5ContactMessages()
        {
            var values = _contactManager.GetLast5ContactMessages();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(Contact contact)
        {
            var validationResult = await _contactValidator.ValidateAsync(contact);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _contactManager.Create(contact);
            return Ok("Contact oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(Contact contact)
        {
            var validationResult = await _contactValidator.ValidateAsync(contact);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _contactManager.Update(new Contact
            {
                ContactID = contact.ContactID,
                Name = contact.Name
            });
            return Ok("Başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveContact(int id)
        {
            var value = await _contactManager.GetById(id);
            await _contactManager.Delete(value);
            return Ok("Başarıyla silindi");
        }
    }
}
