using Core.Utilities.Results;
using Entities.Concrete;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        //bütün arabaları listelemek için;
        IDataResult<List<Car>> GetAll();
        //markasına göre arabaları listelemek için;
        IDataResult<List<Car>> GetByBrandId(int brandId);
        //rengine göre arabaları listelemek için;
        IDataResult<List<Car>> GetByColorId(int colorId);
        //Günlük Para miktarına göre listelemek için
        IDataResult<List<Car>> GetByDailyPrice(int min, int max);
        //id ile arabayı çekmek için
        IDataResult<Car> GetById(int carId);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        //Araba Eklemek için;
        IResult Add(Car car);
        //Araba Silmek için;
        IResult Delete(Car car);
        //Araba Güncellemek için;
        IResult Update(Car car);
        IDataResult<List<Car>> GetCarsByBrandId(int id);
    }
}
