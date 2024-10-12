using System.ComponentModel.DataAnnotations;

namespace  Restaurantium.Dto.AboutDtos    
{
    public class CreateAboutDto
    {
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        [MinLength(30,ErrorMessage ="En az 50 karakter girilmelidir")]
        [MaxLength(50, ErrorMessage ="En fazla 598 karakter girilmelidir")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        [Range(1,255,ErrorMessage ="Deneyim yılı en az 1 ve en fazla 255 yıl olabilir")]
        public byte YearsOfExperience { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Image1Url { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Image2Url { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Image3Url { get; set; }

        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string Image4Url { get; set; }
    }
}
