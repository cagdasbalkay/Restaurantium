using FluentValidation;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.WorkingHourValidators
{
    public class WorkingHourValidator : AbstractValidator<WorkingHour>
    {
        public WorkingHourValidator()
        {
                RuleFor(x => x.WeekendWorkingHours).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
                RuleFor(x => x.WeekDayWorkingHours).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
