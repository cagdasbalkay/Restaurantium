using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string CategoryName { get; set; }
    }
}
