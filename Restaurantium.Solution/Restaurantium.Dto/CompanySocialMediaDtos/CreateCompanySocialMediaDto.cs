using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.CompanySocialMediaDtos
{
    public class CreateCompanySocialMediaDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Platform { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Url { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string IconClass { get; set; }
    }
}
