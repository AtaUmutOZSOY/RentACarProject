using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : BaseManager<Customer>,ICustomerService
    {
        ICustomerDal _customerDal;

        
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

    

        public IResult CheckCustomerByCustomerId(int customerId)
        {
            var result = _customerDal.Get(x => x.CustomerId == customerId);
            if (result != null)
            {
                return new ErrorResult();
            }
            return null;
        }
    }
}
