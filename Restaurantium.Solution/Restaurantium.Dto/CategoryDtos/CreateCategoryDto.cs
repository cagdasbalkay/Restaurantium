using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.CategoryDtos
{
    public class CreateCategoryDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string CategoryName { get; set; }
    }
}
