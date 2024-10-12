using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.WorkingHourValidators;
using Restaurantium.DataAccess.Entities;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingHoursController(WorkingHourManager WorkingHourManager, WorkingHourValidator workingHourValidator) : ControllerBase
    {
        private readonly WorkingHourManager _WorkingHourManager = WorkingHourManager;
        private readonly WorkingHourValidator _workingHourValidator = workingHourValidator;

        [HttpGet]
        public async Task<IActionResult> GetWorkingHours()
        {
            var values = await _WorkingHourManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetWorkingHourById")]
        public async Task<IActionResult> GetWorkingHourById(int id)
        {
            var value = await _WorkingHourManager.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateWorkingHour(WorkingHour WorkingHour)
        {
            var result = await _workingHourValidator.ValidateAsync(WorkingHour);
            if(!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _WorkingHourManager.Create(WorkingHour);
            return Ok("WorkingHour alanı başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkingHour(WorkingHour WorkingHour)
        {
            var result = await _workingHourValidator.ValidateAsync(WorkingHour);
            if (!result.IsValid)
            {
                return BadRequest(result.Errors);
            }
            await _WorkingHourManager.Update(WorkingHour);
            return Ok("WorkingHour alanı başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveWorkingHour(int id)
        {
            var value = await _WorkingHourManager.GetById(id);
            await _WorkingHourManager.Delete(value);
            return Ok("WorkingHour alanı başarıyla silindi");
        }
    }
}
