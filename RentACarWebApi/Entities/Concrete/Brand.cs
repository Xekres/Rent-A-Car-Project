using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand:IEntity
    {
        //araba markasının id si ve markanın adını bu class'ımda tanımlıyorum.
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
