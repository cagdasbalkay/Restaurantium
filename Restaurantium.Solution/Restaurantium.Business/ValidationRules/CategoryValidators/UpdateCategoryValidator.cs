using FluentValidation;
using Restaurantium.Dto.CategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.CategoryValidators
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
