using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BrandValidator:AbstractValidator<Brand>
    {
        public BrandValidator()
        {
            RuleFor(p=>p.BrandId).NotNull();
            RuleFor(p=>p.BrandName).NotNull();
            RuleFor(p => p.BrandName).Length(2);
        }
    }
}
