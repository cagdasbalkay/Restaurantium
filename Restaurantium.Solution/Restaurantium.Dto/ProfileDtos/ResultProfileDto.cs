using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Dto.ProfileDtos
{
    public class ResultProfileDto
    {
        public int UserID { get; set; }
        [Required(ErrorMessage ="Bu alan boş bırakılamaz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]

        public string Password { get; set; }
    }
}
