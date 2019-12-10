/*using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CarPartsStore.Data.Models;
using CarPartsStore.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CarPartsStore.Controllers
{
    public class HomeController : Controller
    {
        private CarPartContext db;
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger, CarPartContext context)
        {
            _logger = logger;
            db = context;
        }
        /*public async Task<IActionResult> Indexing()
        public async Task<IActionResult> Index()
        {
            return View(await db.CarParts.ToListAsync());
        }#1#
            return View(await db.Carparts.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Carpart carpart)
        {
            db.Carparts.Add(carpart);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}*/