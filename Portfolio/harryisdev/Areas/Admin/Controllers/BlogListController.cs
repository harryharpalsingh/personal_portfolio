using harryisdev.Data;
using harryisdev.Models;
using Microsoft.AspNetCore.Mvc;

namespace harryisdev.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogListController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BlogListController(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public IActionResult Index()
        {
            IEnumerable<BlogMaster> objBlogMaster = _dbContext.BlogMaster;
            return View(objBlogMaster);
        }
    }
}
