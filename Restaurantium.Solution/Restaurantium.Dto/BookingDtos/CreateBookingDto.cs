using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.BookingDtos
{
    public class CreateBookingDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Name { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Email { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Date { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public byte NumberOfGuests { get; set; }
        [Required(ErrorMessage = "Eğer özel bir isteğiniz yoksa 'yok' yazınız.")]

        public string SpecialRequest { get; set; }
    }
}
