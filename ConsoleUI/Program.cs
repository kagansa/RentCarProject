using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            //CarAdd(carManager);
            //CarUpdate(carManager);
            //CarDelete(carManager);
            CarsList(carManager);
            CarGetById(carManager);
            CarsGetByColor(carManager);
            CarsGetByBrand(carManager);
        }

        private static void CarsList(CarManager carManager)
        {
            Console.WriteLine("......   ARABA LİSTELEME     ......");
            var cars = carManager.GetAll();
            if (cars.Success)
            {
                foreach (var car in cars.Data)
                {
                    Console.WriteLine(car.Description + " " + car.ModelYear);
                }

                Console.WriteLine(cars.Message);
            }
        }

        private static void CarGetById(CarManager carManager)
        {
            Console.WriteLine("......   ARABA ID Getir     ......");
            var car = carManager.GetById(1);
            if (car.Success)
            {
                Console.WriteLine(car.Data.Description + " " + car.Data.ModelYear);

                Console.WriteLine(car.Message);
            }
        }

        private static void CarsGetByColor(CarManager carManager)
        {
            Console.WriteLine("......   ARABA Renk ID Getir     ......");
            var cars = carManager.GetCarsByColorId(4);
            if (cars.Success)
            {
                foreach (var car in cars.Data)
                {
                    Console.WriteLine(car.Description + " " + car.ModelYear);
                }

                Console.WriteLine(cars.Message);
            }
        }

        private static void CarsGetByBrand(CarManager carManager)
        {
            Console.WriteLine("......   ARABA Brand ID Getir     ......");
            var cars = carManager.GetCarsByBrandId(2);
            if (cars.Success)
            {
                foreach (var car in cars.Data)
                {
                    Console.WriteLine(car.Description + " " + car.ModelYear);
                }

                Console.WriteLine(cars.Message);
            }
        }

        private static void CarAdd(CarManager carManager)
        {
            Console.WriteLine("......   ARABA Ekle     ......");
            Car c = new Car();
            c.BrandId = 1;
            c.ColorId = 3;
            c.ModelYear = "2009";
            c.Description = "Corsa";
            c.DailyPrice = 80;
            var car = carManager.Add(c);
            if (car.Success)
            {
                Console.WriteLine(car.Message);
            }
        }

        private static void CarUpdate(CarManager carManager)
        {
            Console.WriteLine("......   ARABA Güncelle     ......");

            Car c = new Car();
            c.Id = 4;
            c.BrandId = 1;
            c.ColorId = 1;
            c.DailyPrice = 200;
            c.ModelYear = "2020";
            c.Description = "Insignia";
            var update = carManager.Update(c);
            if (update.Success)
            {
                Console.WriteLine(update.Message);
            }
        }

        private static void CarDelete(CarManager carManager)
        {
            Console.WriteLine("......   ARABA Sil     ......");

            Car deleteCar = carManager.GetById(4).Data;
            var delete = carManager.Delete(deleteCar);
            if (delete.Success)
            {
                Console.WriteLine(delete.Message);
            }
        }


    }
}