using Microsoft.AspNetCore.Mvc;

namespace harryisdev.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CreateBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
