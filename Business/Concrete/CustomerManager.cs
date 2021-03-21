using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

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
            //if (customer.Id !=0)
            //{
                _customerDal.Add(customer);
                return new SuccesResult(Messages.CustomerAdded);
            //}
            //else
            //{
            //    return new ErrorResult(Messages.NoCustomerAdded);
            //}
            
        }

        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new SuccesResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccesDataResult<List<Customer>>(_customerDal.GetAll(),Messages.CustomerListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetail()
        {
            return new SuccesDataResult<List<CustomerDetailDto>>(_customerDal.GetCustomerDetails());
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new SuccesResult(Messages.CustomerUpdated);
        }
    }
}
