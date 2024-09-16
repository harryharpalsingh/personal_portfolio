using Microsoft.AspNetCore.Mvc;

namespace harryisdev.Controllers
{
    public class PageNotFound : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
