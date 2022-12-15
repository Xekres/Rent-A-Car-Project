using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Payment2:IEntity
    {
        public int Payment2Id { get; set; }
        public int CustomerId { get; set; }
        public string CreditCardNumber { get; set; }
        public decimal Price { get; set; }
        public string ExpirationDate { get; set; }

        public string CVV { get; set; }
    }
}
