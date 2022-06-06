using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.BusinessRules;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult(Messages.ActionMessages.SuccedAdd);
        }

        public IResult Delete(Customer customer)
        {
            var result = BusinessRulesValidator.Run(IsCustomerExistForDelete(customer.CustomerId));
            if (result.Success)
            {
                _customerDal.Delete(customer);
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ActionMessages.NotExist);
        }

        private IResult IsCustomerExistForDelete (int customerId)
        {
           var result =  _customerDal.Get(x => x.CustomerId == customerId);
            if (result != null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<Customer> GetById(int id)
        {
            var result = _customerDal.Get(x => x.CustomerId == id);
            if (result != null)
            {
                return new SuccessDataResult<Customer>(result);
            }
            return null;
        }

        public IDataResult<List<Customer>> GetAll()
        {
            var customers = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(customers);
        }

        public IResult Update(Customer customer)
        {
            var result = BusinessRulesValidator.Run(CheckExistCustomerForUpdate(customer.CustomerId));
            if (result != null)
            {
                _customerDal.Update(customer);
                return new SuccessResult(Messages.ActionMessages.SuccedUpdate);
            }
            return new ErrorResult(Messages.ActionMessages.NotExist);
        }

        private IResult CheckExistCustomerForUpdate(int customerId)
        {
            var result = _customerDal.Get(x => x.CustomerId == customerId);
            if (result != null)
            {
                return new SuccessResult(true);
            }
            return new ErrorResult(false);
        }
    }
}
