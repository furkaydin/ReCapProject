using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService,IBrandService,IColorService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car,Brand brand)
        {
            if(brand.Name.Length>2 && car.DailyPrice > 0)
            {
                _carDal.Add(car);
                Console.WriteLine("Araç eklendi.");
            } else
            {
                Console.WriteLine("Aracın ismi minimum 2 karakter olmalı veya günlük fiyatı 0'dan büyük olmalı.");
            }
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(p => p.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(p => p.ColorId == id);
        }
    }
}
