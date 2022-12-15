using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IPayment2Service
    {
        IDataResult<List<Payment2>> GetAll();
        IResult Add(Payment2 payment2);
        IResult Update(Payment2 payment2);
        IResult Delete(Payment2 payment2);
        IDataResult<Payment2> Get(Payment2 payment2);
        IDataResult<Payment2> GetById(int Id);
    }
}
