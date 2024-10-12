using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.TestimonialDtos
{
    public class CreateTestimonialDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Profession { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string ImageUrl { get; set; }
    }
}
