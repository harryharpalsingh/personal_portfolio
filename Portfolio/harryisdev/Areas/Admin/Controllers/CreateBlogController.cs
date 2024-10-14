using harryisdev.Data;
using harryisdev.Models;
using Microsoft.AspNetCore.Mvc;

namespace harryisdev.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CreateBlogController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreateBlogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogMaster blogMaster)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.BlogMaster.Add(blogMaster);
                    _context.SaveChanges();

                    // Set the success message in TempData
                    TempData["SuccessMessage"] = "Blog has been created successfully!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception and handle the error accordingly
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the blog. Please try again.");
                }
            }

            // If ModelState is invalid, return the 'Index' view, not 'Create'
            return View("Index", blogMaster);
        }
    }
}
