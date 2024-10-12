using FluentValidation;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.ChefValidators
{
    public class ChefValidator : AbstractValidator<Chef>
    {
        public ChefValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Profession).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.FacebookUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.TwitterUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.InstagramUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
