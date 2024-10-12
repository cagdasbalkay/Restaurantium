using FluentValidation;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.ServiceValidators
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator()
        {
                RuleFor(x => x.ServiceName).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
                RuleFor(x => x.IconUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
                RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
