using FluentValidation;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.FooterContactValidators
{
    public class FooterContactValidator : AbstractValidator<FooterContact>
    {
        public FooterContactValidator()
        {
                RuleFor(x => x.Address).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
                RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
                RuleFor(x => x.Phone).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
