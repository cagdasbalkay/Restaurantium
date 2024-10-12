using FluentValidation;
using Restaurantium.Dto.FoodDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.FoodValidators
{
    public class CreateFoodValidator : AbstractValidator<CreateFoodDto>
    {
        public CreateFoodValidator()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.FoodName).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            
        }
    }
}
