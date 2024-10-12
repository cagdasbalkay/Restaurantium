using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.FoodValidators;
using Restaurantium.DataAccess.Abstract;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.FoodDtos;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodsController : ControllerBase
    {
        private readonly FoodMenuManager _foodMenuManager;
        private readonly FoodManager _foodManager;
        private readonly CreateFoodValidator _createFoodValidator;
        private readonly UpdateFoodValidator _updateFoodValidator;


        public FoodsController(FoodMenuManager foodMenuManager, FoodManager foodManager, CreateFoodValidator createFoodValidator, UpdateFoodValidator updateFoodValidator)
        {
            _foodMenuManager = foodMenuManager;
            _foodManager = foodManager;
            _createFoodValidator = createFoodValidator;
            _updateFoodValidator = updateFoodValidator;
        }

        [HttpGet("GetFoodsByCategoryId")]
        public IActionResult GetFoodsByCategoryId(int id)
        {
            var values = _foodMenuManager.GetFoodsByCategoryId(id);
            return Ok(values);
        }

        [HttpGet("Get8FoodsPerCategory")]
        public IActionResult Get8FoodsPerCategory(int id)
        {
            var values = _foodMenuManager.Get8FoodsPerCategory(id);
            return Ok(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var values = await _foodManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetFoodById")]
        public async Task<IActionResult> GetFoodById(int id)
        {
            var value = await _foodManager.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateFood(CreateFoodDto FoodDto)
        {
           var validationResult = await _createFoodValidator.ValidateAsync(FoodDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }

            await _foodManager.Create(new Food
            {
                FoodName = FoodDto.FoodName,
                Description = FoodDto.Description,
                ImageUrl = FoodDto.ImageUrl,
                Price = FoodDto.Price
            });
            return Ok("Başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFood(UpdateFoodDto FoodDto)
        {
            var validationResult = await _updateFoodValidator.ValidateAsync(FoodDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _foodManager.Update(new Food
            {
                FoodID = FoodDto.FoodID,
                FoodName = FoodDto.FoodName,
                Price= FoodDto.Price,
                ImageUrl= FoodDto.ImageUrl,
                Description = FoodDto.Description
            });
            return Ok("Başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveFood(int id)
        {
            var value = await _foodManager.GetById(id);
            await _foodManager.Delete(value);
            return Ok("Başarıyla silindi");
        }
    }
}
