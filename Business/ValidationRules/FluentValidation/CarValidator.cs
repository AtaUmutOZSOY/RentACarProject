using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.ModelYear).GreaterThan(1950);
            RuleFor(p =>p.CarId).NotNull();
            RuleFor(p=>p.BrandId).NotNull();
            RuleFor(p=>p.ColorId).NotNull();
            RuleFor(p => p.DailyPrice).NotNull();
            RuleFor(p => p.DailyPrice).GreaterThan(0);

           
        }
    }
}
