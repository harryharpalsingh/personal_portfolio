using harryisdev.Data;
using harryisdev.Models;
using Microsoft.AspNetCore.Mvc;

namespace harryisdev.Controllers
{
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BlogController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<BlogMaster> objBlogList = _dbContext.BlogMaster;
            return View(objBlogList);
        }
    }
}
