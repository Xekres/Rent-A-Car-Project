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
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarContext>, ICarDal
    {
        public List<CarDetailDto> GetCarDetails()
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             join c1 in context.Colors
                             on c.ColorId equals c1.ColorId

                             select new CarDetailDto
                             {
                                 Id = c.Id,
                                 BrandName = b.BrandName,
                                 ColorName = c1.ColorName,
                                 DailyPrice = c.DailyPrice,
                                 _Description = c._Description,
                                 ModelYear = c.ModelYear,
                             };
                return result.ToList();
            }
        }

        public CarDetailDto GetCarDetails(int carId)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from car in context.Cars.Where(c => c.Id == carId)

                             join color in context.Colors
                             on car.ColorId equals color.ColorId

                             join brand in context.Brands
                             on car.BrandId equals brand.BrandId

                             select new CarDetailDto()
                             {
                                 Id = car.Id,
                         
                                 BrandName = brand.BrandName,
                                
                                 
                                 ColorName = color.ColorName,


                                 DailyPrice = car.DailyPrice,
                                 _Description = car._Description,
                                 ModelYear = car.ModelYear,

                                 
                             };

                return result.SingleOrDefault();
            }
        }
    }
    
}

