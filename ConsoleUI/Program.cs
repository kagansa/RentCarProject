using Business.Concrete;
using Entities.Concrete;
using System;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EfCarDal());

            CarsDetailsList(carManager);
            ////CarAdd(carManager);
            ////CarUpdate(carManager);
            ////CarDelete(carManager);
            //CarsList(carManager);
            //CarGetById(carManager);
            //CarsGetByColor(carManager);
            //CarsGetByBrand(carManager);

            //BrandManager brandManager = new BrandManager(new EfBrandDal());

            ////BrandAdd(brandManager);
            ////BrandUpdate(brandManager);
            ////BrandDelete(brandManager);
            //BrandsList(brandManager);
            //BrandsGetById(brandManager);

            //ColorManager colorManager = new ColorManager(new EfColorDal());

            ////ColorAdd(colorManager);
            ////ColorUpdate(colorManager);
            ////ColorDelete(colorManager);
            //ColorsList(colorManager);
            //ColorGetById(colorManager);
        }

        #region Colors

        private static void ColorsList(ColorManager colorManager)
        {
            Console.WriteLine("......   Renk Listeleme     ......");
            var colors = colorManager.GetAll();
            if (colors.Success)
            {
                foreach (var color in colors.Data)
                {
                    Console.WriteLine(color.Name);
                }

                Console.WriteLine(colors.Message);
            }
        }

        private static void ColorGetById(ColorManager colorManager)
        {
            Console.WriteLine("......   Renk ID Getir     ......");
            var colors = colorManager.GetById(1);
            if (colors.Success)
            {
                Console.WriteLine(colors.Data.Name);

                Console.WriteLine(colors.Message);
            }
        }

        private static void ColorAdd(ColorManager colorManager)
        {
            Console.WriteLine("......   Renk Ekle     ......");
            Color color = new Color();
            color.Name = "Gri";
            var result = colorManager.Add(color);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorUpdate(ColorManager colorManager)
        {
            Console.WriteLine("......   Renk Güncelle     ......");
            Color color = colorManager.GetById(5).Data;
            color.Name = "Füme";
            var result = colorManager.Update(color);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void ColorDelete(ColorManager colorManager)
        {
            Console.WriteLine("......   Renk Sil     ......");
            Color color = colorManager.GetById(6).Data ?? throw new ArgumentNullException("colorManager.GetById(6).Data");
            var result = colorManager.Delete(color);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion Colors

        #region Brands

        private static void BrandsList(BrandManager brandManager)
        {
            Console.WriteLine("......   MARKA LİSTELEME     ......");
            var brands = brandManager.GetAll();
            if (brands.Success)
            {
                foreach (var brand in brands.Data)
                {
                    Console.WriteLine(brand.Name);
                }

                Console.WriteLine(brands.Message);
            }
        }

        private static void BrandsGetById(BrandManager brandManager)
        {
            Console.WriteLine("......   MARKA ID Getir     ......");
            var brands = brandManager.GetById(1);
            if (brands.Success)
            {
                Console.WriteLine(brands.Data.Name);

                Console.WriteLine(brands.Message);
            }
        }

        private static void BrandAdd(BrandManager brandManager)
        {
            Console.WriteLine("......   MARKA Ekle     ......");
            Brand brand = new Brand();
            brand.Name = "Skoda";
            var result = brandManager.Add(brand);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandUpdate(BrandManager brandManager)
        {
            Console.WriteLine("......   MARKA Güncelle     ......");
            Brand brand = brandManager.GetById(8).Data;
            brand.Name = "Skoda X";
            var result = brandManager.Update(brand);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void BrandDelete(BrandManager brandManager)
        {
            Console.WriteLine("......   MARKA Sil     ......");
            Brand brand = brandManager.GetById(8).Data;
            var result = brandManager.Delete(brand);
            if (result.Success)
            {
                Console.WriteLine(result.Message);
            }
        }

        #endregion Brands

        #region Cars

        private static void CarsDetailsList(CarManager carManager)
        {
            Console.WriteLine("......   ARABA Detaylı LİSTELEME     ......");
            var cars = carManager.GetDetailsAll();
            if (cars.Success)
            {
                foreach (var car in cars.Data)
                {
                    Console.WriteLine(car.CarId + " " + car.BrandName + " " + car.CarName + " " + car.ColorName + " " + car.DailyPrice);
                }

                Console.WriteLine(cars.Message);
            }
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

        #endregion Cars
    }
}