using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.ServiceDtos
{
    public class CreateServiceDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string serviceName { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string description { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string iconUrl { get; set; }
    }
}
