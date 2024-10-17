using harryisdev.Data;
using harryisdev.Models;
using Microsoft.AspNetCore.Mvc;

namespace harryisdev.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ModifyBlogController : Controller
    {
        private readonly ApplicationDbContext _dbcontext;

        public ModifyBlogController(ApplicationDbContext context)
        {
            _dbcontext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<BlogMaster> objBlogList = _dbcontext.BlogMaster;
            return View(objBlogList);
        }
    }
}
