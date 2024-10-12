using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.FooterContactDtos
{
    public class UpdateFooterContactDto
    {
        public int FooterContactID { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Email { get; set; }
    }
}
