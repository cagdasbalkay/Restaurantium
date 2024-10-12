using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurantium.Business.Concrete;
using Restaurantium.Business.ValidationRules.CategoryValidators;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.CategoryDtos;

namespace Restaurantium.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController(CategoryManager CategoryManager, CreateCategoryValidator createCategoryValidator,
     UpdateCategoryValidator updateCategoryValidator) : ControllerBase
    {
        private readonly CategoryManager _CategoryManager = CategoryManager;
        private readonly CreateCategoryValidator _createCategoryValidator = createCategoryValidator;
        private readonly UpdateCategoryValidator _updateCategoryValidator = updateCategoryValidator;

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var values = await _CategoryManager.GetAll();
            return Ok(values);
        }

        [HttpGet("GetCategoryById")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var value = await _CategoryManager.GetById(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
        {
            var validationResult = await _createCategoryValidator.ValidateAsync(categoryDto);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _CategoryManager.Create(new Category
            {
                CategoryName = categoryDto.CategoryName
            });
            return Ok("Başarıyla oluşturuldu");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto categoryDto)
        {
            var validationResult = await _updateCategoryValidator.ValidateAsync(categoryDto);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors);
            }
            await _CategoryManager.Update(new Category
            {
                CategoryID = categoryDto.CategoryID,
                CategoryName = categoryDto.CategoryName
            });
            return Ok("Başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveCategory(int id)
        {
            var value = await _CategoryManager.GetById(id);
            await _CategoryManager.Delete(value);
            return Ok("Başarıyla silindi");
        }
    }
}
