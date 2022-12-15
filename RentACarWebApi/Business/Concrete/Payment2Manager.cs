using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class Payment2Manager:IPayment2Service
    {
        IPayment2Dal _paymentDal;
        ICustomerService _customerService;
        ICreditCardService _creditCardService;
        public Payment2Manager(IPayment2Dal paymentDal, ICustomerService customerService, ICreditCardService creditCardService)
        {
            _paymentDal = paymentDal;
            _customerService = customerService;
            _creditCardService = creditCardService;
        }

        public IResult Add(Payment2 payment)
        {
            IResult result = BusinessRules.Run(
                CheckIsCreditCardExist(payment.CreditCardNumber, payment.ExpirationDate, payment.CVV));

            if (result != null)
            {
                return result;
            }
            _paymentDal.Add(payment);

            return new SuccessResult("Payment" + Messages.SuccessAdded);
        }

        public IResult Delete(Payment2 payment)
        {
            _paymentDal.Delete(payment);
            return new SuccessResult("Payment" + Messages.SuccessDeleted);
        }



        public IDataResult<Payment2> Get(Payment2 payment)
        {
            return new SuccessDataResult<Payment2>(_paymentDal.Get(x => x.Payment2Id == payment.Payment2Id));
        }



        public IDataResult<List<Payment2>> GetAll()
        {
            return new SuccessDataResult<List<Payment2>>(_paymentDal.GetAll());
        }

        public IDataResult<Payment2> GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public IResult GetList(List<Payment2> list)
        {
            throw new NotImplementedException();
        }

        public IResult Update(Payment2 payment)
        {
            _paymentDal.Update(payment);
            return new SuccessResult("Payment" + Messages.SuccessUpdated);
        }

        private IResult CheckIsCreditCardExist(string cardNumber, string expirationDate, string CVV)
        {
            if (_creditCardService.GetAll().Data.Any(c => c.CreditCardNumber == cardNumber))
            {
                if (!_creditCardService.GetAll().Data.Any(
                    c => c.CreditCardNumber == cardNumber &&
                    c.ExpirationDate == expirationDate &&
                    c.CVV == CVV
                    ))
                {
                    return new ErrorResult(Messages.NotExist + "credit card");
                }
            }
            return new SuccessResult();
        }
    }
}
