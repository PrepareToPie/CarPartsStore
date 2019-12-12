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
                        Car = Cars["ASdasf12312s"],
                        Category = Categories["��������� �����"],
                        Name = "BMW original",
                        Manufacturer = "Germany",
                        InStock = 23,
                        Price = 10000,
                        ShortDescription = "������������ ��������� �����",
                        LongDescription = "������������ � ������������������ ��������� �����",
                        ImageUrl = "/image/bmw_brake.jpg",
                        ImageThumbnailUrl = "/image/bmw_brake.jpg"
                    },
                    new Carpart
                    {
                        Car = Cars["ASdasf12312s"],
                        Category = Categories["��������� �����"],
                        Name = "ShanJo",
                        Manufacturer = "China",
                        InStock = 21,
                        Price = 3000,
                        ShortDescription = "�������������� ��������� �����",
                        LongDescription = "�������������� � �������������� ��������� �����",
                        ImageUrl = "/image/bmw_brake_noorig.jpg",
                        ImageThumbnailUrl = "/image/bmw_brake_noorig.jpg"
                    },
                    new Carpart
                    {
                        Car = Cars["HTtbda32132n"],
                        Category = Categories["��������� �����"],
                        Name = "Toyota original",
                        Manufacturer = "Japan",
                        InStock = 12,
                        Price = 6000,
                        ShortDescription = "������������ ��������� �����",
                        LongDescription = "������������ � ������������������ ��������� �����",
                        ImageUrl = "/image/toyota_brake.jpg",
                        ImageThumbnailUrl = "/image/toyota_brake.jpg"
                    },
                    new Carpart
                    {
                        Car = Cars["HTtbda32132n"],
                        Category = Categories["�������� ����"],
                        Name = "Michelin",
                        Manufacturer = "France",
                        InStock = 5,
                        Price = 8000,
                        ShortDescription = "������ ����",
                        LongDescription = "������������������ ������������ ������ ����",
                        ImageUrl = "/image/michelin.jpg",
                        ImageThumbnailUrl = "/image/michelin.jpg"
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
                        new Category {CategoryName = "��������� �����", Description = "�������� ��������� ������"},
                        new Category {CategoryName = "�������� ����", Description = "�������� ������ ���"}
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
                        new Car {Vin = "HTtbda32132n", Mark = "Toyota", Model = "Camry"}
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