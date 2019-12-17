using Microsoft.AspNetCore.Mvc;
namespace CarPartsStore.Controllers
{
    public class ContactController: Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}