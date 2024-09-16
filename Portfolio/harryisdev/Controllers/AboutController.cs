using Microsoft.AspNetCore.Mvc;

namespace harryisdev.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
