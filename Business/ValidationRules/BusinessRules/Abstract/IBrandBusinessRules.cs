using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.BusinessRules.Abstract
{
    public interface IBrandBusinessRules
    {
        IResult CheckExistBrand(string brandName);
        IResult CheckExistBrandForUpdate(string brandName);
    }
}
