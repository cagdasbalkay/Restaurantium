using FluentValidation;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.BannerValidators
{
    public class BannerValidator : AbstractValidator<Banner>
    {
        public BannerValidator()
        {
                RuleFor(x => x.Title).NotEmpty().WithMessage("Bu alan boş bırakılamaz").MinimumLength(26).WithMessage("Lütfen en az 26 karakterlik bir veri girişi yapınız").MaximumLength(36).WithMessage("Lütfen 36 karakteri geçmeyecek şekilde veri girişi yapınız");
                RuleFor(x => x.Description).NotEmpty().MinimumLength(160).WithMessage("Lütfen en az 160 karakterlik bir veri girişi yapınız").WithMessage("Bu alan boş bırakılamaz").MaximumLength(410).WithMessage("Lütfen 410 karakteri geçmeyecek şekilde veri girişi yapınız");
        }
    }
}
