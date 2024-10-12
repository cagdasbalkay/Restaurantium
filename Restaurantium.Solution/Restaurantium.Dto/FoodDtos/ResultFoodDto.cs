namespace Restaurantium.Dto.FoodDtos
{
    public class ResultFoodDto
    {
        public int FoodID { get; set; }
        public string FoodName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}
