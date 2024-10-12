using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.SubscribeDtos
{
    public class CreateSubscribeDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }
    }
}
