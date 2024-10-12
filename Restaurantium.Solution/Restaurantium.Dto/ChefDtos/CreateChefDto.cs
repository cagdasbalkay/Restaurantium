using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.ChefDtos
{
    public class CreateChefDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Profession { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string FacebookUrl { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string TwitterUrl { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string InstagramUrl { get; set; }
    }
}
