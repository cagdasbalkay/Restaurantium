using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Dto.AppUserDtos
{
    public class ResultSignInDto
    {
        [Required(ErrorMessage ="Kullanıcı adı girilmesi zorunludur")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre girilmesi zorunludur")]

        public string Password { get; set; }
    }
}
