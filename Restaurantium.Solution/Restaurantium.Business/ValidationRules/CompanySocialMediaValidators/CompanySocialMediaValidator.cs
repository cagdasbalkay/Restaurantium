using FluentValidation;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.CompanySocialMediaValidators
{
    public class CompanySocialMediaValidator : AbstractValidator<CompanySocialMedia>
    {
        public CompanySocialMediaValidator()
        {
            RuleFor(x => x.Platform).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Url).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.IconClass).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
    }
       
    }
}
