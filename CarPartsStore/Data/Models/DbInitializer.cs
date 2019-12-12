using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace CarPartsStore.Data.Models

{
    public class DbInitializer
    {

        public static void Seed(IServiceProvider applicationBuilder)
        {
            AppDbContext context = applicationBuilder.GetRequiredService<AppDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Cars.Any())
            {
                context.Cars.AddRange(Cars.Select(c => c.Value));
            }

            if (!context.Carparts.Any())
            {
                context.AddRange(
                    new Carpart
                    {
                        Car = Cars["VIN"],
                        Category = Categories["Category 1"],
                        Name = "Detail 1",
                        Manufacturer = "Manufacturer 1",
                        InStock = 123,
                        Price = 1230,
                        ShortDescription = "Short descript",
                        LongDescription = "Long descript",
                        ImageUrl = "/home/ilsur/RiderProjects/CarPartsStore/CarPartsStore/wwwroot/images/img1.jpg",
                        ImageThumbnailUrl =
                            "/home/ilsur/RiderProjects/CarPartsStore/CarPartsStore/wwwroot/images/img1.jpg"
                    },
                new Carpart
                    {
                        Car = Cars["ASdasf12312s"],
                        Category = Categories["Category 2"],
                        Name = "Detail 2",
                        Manufacturer = "Manufacturer 2",
                        InStock = 1232,
                        Price = 12300,
                        ShortDescription = "Short descript",
                        LongDescription = "Long descript",
                        ImageUrl = "/home/ilsur/RiderProjects/CarPartsStore/CarPartsStore/wwwroot/images/img1.jpg",
                        ImageThumbnailUrl = "/home/ilsur/RiderProjects/CarPartsStore/CarPartsStore/wwwroot/images/img1.jpg"
                    }
                    );
            }

            context.SaveChanges();

        }

        private static Dictionary<string, Category> _categories;
        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var genresList = new Category[]
                    {
                        new Category {CategoryName = "Category 1", Description = "All category 1"},
                        new Category {CategoryName = "Category 2", Description = "All category 2"}
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach (Category genre in genresList)
                    {
                        _categories.Add(genre.CategoryName, genre);
                    }
                }

                return _categories;
            }
        }

        public static Dictionary<string, Car> _cars;

        public static Dictionary<string, Car> Cars
        {
            get
            {
                if (_cars == null)
                {
                    var carList = new Car[]
                    {
                        new Car {Vin = "ASdasf12312s", Mark = "BMW", Model = "i8"},
                        new Car {Vin = "VIN", Mark = "Mark", Model = "Model"}
                    };
                    _cars = new Dictionary<string, Car>();
                    foreach (var car in carList)
                    {
                        Cars.Add(car.Vin, car);
                    }
                }
                return _cars;
            }
        }
    }

}