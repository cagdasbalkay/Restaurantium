using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.ContactDtos
{
    public class CreateContactDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Message { get; set; }
    }
}
