using FluentValidation;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.BookingValidators
{
    public class BookingValidator : AbstractValidator<Booking>
    {
        public BookingValidator() 
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Bu alan boş bırakılamaz").EmailAddress().WithMessage("Email formatında olmalıdır.");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.NumberOfGuests).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
            RuleFor(x => x.SpecialRequest).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
        }
      
    }
}
