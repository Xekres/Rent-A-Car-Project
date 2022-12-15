using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework.EfDals
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in context.Rentals
                                 
                             join c in context.Cars
                             on r.CarId equals c.Id
                             join cu in context.Customers
                             on r.CustomerId equals cu.CustomerId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join color in context.Colors
                             on c.ColorId equals color.ColorId
                             join u in context.Users
                            on cu.UserId equals u.Id
                             select new RentalDetailDto
                             {
                                 RentalId = r.Id,
                                 BrandName = b.BrandName,
                                 
                                 ColorName = color.ColorName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 UserName = u.FirstName + " " + u.LastName,
                                 

                             };


                return result.ToList();
            }
        }
    }
}
