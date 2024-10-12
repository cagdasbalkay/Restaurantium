using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.BannerDtos
{
    public class CreateBannerDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string title { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string description { get; set; }
    }
}
