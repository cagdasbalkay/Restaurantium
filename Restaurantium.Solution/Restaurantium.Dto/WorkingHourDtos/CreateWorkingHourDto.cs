using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.WorkingHourDtos
{
    public class CreateWorkingHourDto
    {
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string WeekDayWorkingHours { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string WeekendWorkingHours { get; set; }
    }
}
