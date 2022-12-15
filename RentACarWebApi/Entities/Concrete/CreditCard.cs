using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int CreditCardId { get; set; }
        public int CustomerId { get; set; }
        public string OwnerName { get; set; }
        public string CreditCardNumber { get; set; }
        public string CVV { get; set; }
        public string ExpirationDate { get; set; }
    }
}
