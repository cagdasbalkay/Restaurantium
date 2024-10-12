using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.StatisticDtos
{
    public class UpdateSubscribeDto
    {
        public int SubscribeID { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }
    }
}
