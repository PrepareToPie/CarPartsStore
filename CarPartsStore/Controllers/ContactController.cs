using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace CarPartsStore.Controllers
{
    [Authorize(Roles = "user")]
    public class ContactController: Controller
    {
        public ViewResult Index()
        {
            return View();
        }
    }
}