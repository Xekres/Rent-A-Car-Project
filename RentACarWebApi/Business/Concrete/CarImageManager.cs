using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualStudio.TestPlatform.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileHelper = Core.Utilities.FileHelper.FileHelper;

namespace Business.Concrete
{
    public class CarImageManager:ICarImageService
    {
        ICarImageDal _carImageDal;
        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }
        
        
        public IResult Add(CarImage carImage, IFormFile file)
        {
            IResult result = BusinessRules.Run(
                CheckIfImageLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        
        public IResult Update(CarImage carImage, IFormFile file)
        {
            var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
            carImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);

            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        
        public IResult Delete(CarImage carImage)
        {
            var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_carImageDal.Get(p => p.Id == carImage.Id).ImagePath}";
            FileHelper.DeleteAsync(oldpath);

            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }


       
        public IDataResult<List<CarImage>> GetAll()
        {
            //Thread.Sleep(6000);
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }

        
        public IDataResult<List<CarImage>> GetImagesByCarId(int CarId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == CarId).Any();
            if (!result)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = CarId, ImagePath = @"\Images\default1.jpg" });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(p => p.CarId == CarId));
        }

        private IResult CheckIfImageLimit(int CarId)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == CarId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }

            return new SuccessResult();
        }

        
        


        public IDataResult<CarImage> GetById(int Id)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p => p.Id == Id)); ;
        }

    }
}
