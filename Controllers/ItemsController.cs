using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    public class ItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
