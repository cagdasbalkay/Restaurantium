using System.ComponentModel.DataAnnotations;

namespace Restaurantium.Dto.WorkingHourDtos
{
    public class UpdateWorkingHourDto
    {
        public int WorkingHourID { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string WeekDayWorkingHours { get; set; }
        [Required(ErrorMessage = "Bu alan boş bırakılamaz")]
        public string WeekendWorkingHours { get; set; }
    }
}
