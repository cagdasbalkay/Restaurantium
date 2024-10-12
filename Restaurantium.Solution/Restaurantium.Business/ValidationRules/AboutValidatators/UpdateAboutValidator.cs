using FluentValidation;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.AboutDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.AboutValidatators
{
    public class UpdateAboutValidator : AbstractValidator<About>
    {
        public UpdateAboutValidator()
        {
            RuleFor(x => x.Description)
        .NotEmpty().WithMessage("Açıklama alanı boş geçilemez!")
        .MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik bir veri girişi yapınız!")
        .MaximumLength(598).WithMessage("Lütfen 598 karakteri geçmeyecek şekilde veri girişi yapınız!");

            RuleFor(x => x.YearsOfExperience)
        .NotEmpty().WithMessage("Deneyim alanı boş geçilemez!")
        .Must(x => x > 0 && x <= 255).WithMessage("Deneyim yılı en fazla 255 olabilir.");


            RuleFor(x => x.Image1Url)
                    .NotEmpty().WithMessage("Görsel 1 URL alanı boş geçilemez!");

            RuleFor(x => x.Image2Url)
                    .NotEmpty().WithMessage("Görsel 2 URL alanı boş geçilemez!");

            RuleFor(x => x.Image3Url)
                    .NotEmpty().WithMessage("Görsel 3 URL alanı boş geçilemez!");

            RuleFor(x => x.Image4Url)
                    .NotEmpty().WithMessage("Görsel 4 URL alanı boş geçilemez!");
        }
    }
}
