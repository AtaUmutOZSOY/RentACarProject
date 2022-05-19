using Core.Entity.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.BusinessRules.Abstract
{
    public interface IAuthBusinessRules
    {
        IResult CheckUserExist(string email);
        IDataResult<User> CheckUserExistForLogin(string email);

    }
}
