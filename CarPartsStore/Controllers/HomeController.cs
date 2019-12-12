using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarPartsStore.Data.Interfaces;
using CarPartsStore.Data.Models;
using CarPartsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarPartsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICarpartRepository _carpartRepository;

        public HomeController(ICarpartRepository carpartRepository)
        {
            _carpartRepository = carpartRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                IsInStock = _carpartRepository.IsInStock
            };
            return View(homeViewModel);
        }
    }
}