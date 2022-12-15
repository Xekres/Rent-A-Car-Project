﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EfDals
{
    public class EfCreditCardDal:EfEntityRepositoryBase<CreditCard, RentACarContext>, ICreditCardDal
    {
    }
}
