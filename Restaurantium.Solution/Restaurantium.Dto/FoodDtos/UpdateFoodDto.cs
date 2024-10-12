using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.FoodDtos
{
    public class UpdateFoodDto
    {
        public int FoodID { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string FoodName { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string ImageUrl { get; set; }
    }
}
