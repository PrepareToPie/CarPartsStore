using CarPartsStore.Data.Interfaces;
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

        public ViewResult List()
        {
            ViewBag.Name = "Carparts list";
            CarpartListViewModel vm = new CarpartListViewModel
            {
                Carparts = _carpartRepository.Carparts, CurrentCategory = "CarpartCategory"
            };

            return View(vm);
        }
    }
}