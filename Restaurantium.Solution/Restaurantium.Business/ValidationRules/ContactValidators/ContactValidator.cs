using FluentValidation;
using Restaurantium.DataAccess.Entities;
using Restaurantium.Dto.ContactDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.ContactValidators
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Message).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
    }
}
