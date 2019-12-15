using System;
using System.Collections.Generic;
using System.Linq;
using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;
using CarPartsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CarPartsStore.Controllers
{
    public class CarpartController:Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICarpartRepository _carpartRepository;

        public CarpartController(ICategoryRepository categoryRepository, ICarpartRepository carpartRepository)
        {
            _categoryRepository = categoryRepository;
            _carpartRepository = carpartRepository;
        }

        public ViewResult List(string category)
        {
            string _category = category;
            IEnumerable<Carpart> carparts;
            string currentCategory = string.Empty;
            if (string.IsNullOrEmpty(category))
            {
                carparts = _carpartRepository.Carparts.OrderBy(n => n.CarpartId);
                currentCategory = "Все запчасти";
            }
            else
            {
                if (string.Equals("Категория1", _category, StringComparison.OrdinalIgnoreCase))
                {
                    carparts = _carpartRepository.Carparts.Where((p => p.Category.CategoryName.Equals("Категория1")));
                }
                else
                {
                    carparts = _carpartRepository.Carparts.Where((p => p.Category.CategoryName.Equals("Категория2")));
                }

                currentCategory = _category;
            }

            var carpartListViewModel = new CarpartListViewModel
            {
                Carparts = carparts,
                CurrentCategory = currentCategory
            };
            return View(carpartListViewModel);
        }
    }
}