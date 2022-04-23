using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator:AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(x => x.Id).NotNull();
            RuleFor(x => x.CarId).NotNull();
            RuleFor(x => x.Date).NotNull();
            RuleFor(x => x.ImagePath).NotNull();

        }
    }
}
