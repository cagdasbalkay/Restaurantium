using FluentValidation;
using Restaurantium.Dto.SubscribeDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.SubscribeValidator
{
    public class CreateSubscribeValidator : AbstractValidator<CreateSubscribeDto>
    {
        public CreateSubscribeValidator()
        {
                RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
