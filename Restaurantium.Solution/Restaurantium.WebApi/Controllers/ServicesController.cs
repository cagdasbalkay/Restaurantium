using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.ServiceValidators;
using Restaurantium.DataAccess.Entities;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ServiceManager _serviceManager;
        private readonly ServiceValidator _serviceValidator;

        public ServicesController(ServiceManager serviceManager, ServiceValidator serviceValidator)
        {
            _serviceManager = serviceManager;
            _serviceValidator = serviceValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServices()
        {
           var values = await _serviceManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetLast4Services")]
        public async Task<IActionResult> GetLast4Services()
        {
            var values = await _serviceManager.GetLast4ServicesAsync();
            return Ok(values);
        }

        [HttpGet("GetServiceById")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var value = await _serviceManager.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateService(Service Service)
        {
            var result = await _serviceValidator.ValidateAsync(Service);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _serviceManager.Create(Service);
            return Ok("Service alanı başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(Service Service)
        {
            var result = await _serviceValidator.ValidateAsync(Service);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _serviceManager.Update(Service);
            return Ok("Service alanı başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
            var value = await _serviceManager.GetById(id);
            await _serviceManager.Delete(value);
            return Ok("Service alanı başarıyla silindi");
        }
    }
}
