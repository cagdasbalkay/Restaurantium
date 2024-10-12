using FluentValidation;
using Restaurantium.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurantium.Business.ValidationRules.TestimonialValidators
{
    public class TestimonialValidator : AbstractValidator<Testimonial>
    {
        public TestimonialValidator()
        {
                RuleFor(x=> x.Name).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
                RuleFor(x=> x.Profession).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
                RuleFor(x=> x.Comment).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
                RuleFor(x=> x.ImageUrl).NotEmpty().WithMessage("Bu alan boş bırakılamaz");
               
        }
    }
}
