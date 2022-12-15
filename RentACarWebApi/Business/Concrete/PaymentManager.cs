using Business.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PaymentManager:IPaymentService
    {
        public IResult MakePayment(Payment payment)
        {
            if (payment.Amount < 1000)
            {
                return new ErrorResult("PAYMENT TEST ERROR");
            }
            return new SuccessResult();
        }
    }
}
