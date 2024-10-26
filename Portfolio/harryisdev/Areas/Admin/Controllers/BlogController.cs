using harryisdev.Data;
using harryisdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace harryisdev.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BlogController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<BlogMaster> objBlogMaster = _dbContext.BlogMaster;
            return View(objBlogMaster);
        }

        //Get
        public IActionResult Create()
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
                    _dbContext.BlogMaster.Add(blogMaster);
                    _dbContext.SaveChanges();

                    // Set the success message in TempData
                    TempData["SuccessMessage"] = "Blog has been created successfully!";
                    //return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Log the exception and handle the error accordingly
                    ModelState.AddModelError(string.Empty, "An error occurred while saving the blog. Please try again.");
                }
            }

            return View();
        }

        //Get - Edit
        public IActionResult Edit(int? id)
        {
            if (id == null && id <= 0)
            {
                return NotFound();
            }

            var blogFromDatabase = _dbContext.BlogMaster.Find(id);
            if (blogFromDatabase == null)
            {
                return NotFound();
            }

            //to return JSON
            //return Ok(blogFromDatabase);

            return View(blogFromDatabase);
        }

        //Post -Edit
        [HttpPost]
        public IActionResult Edit(BlogMaster blog)
        {
            if (!ModelState.IsValid)
            {
                // Set the success message in TempData
                TempData["ErrorMessage"] = "Model state is not valid!";
                return View();
            }

            try
            {
                _dbContext.BlogMaster.Update(blog);
                _dbContext.SaveChanges();
                // Set the success message in TempData
                TempData["SuccessMessage"] = "Blog has been updated successfully!";
            }
            catch (Exception en)
            {
                ModelState.AddModelError(string.Empty, "System error : " + en.Message.ToString());
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBlog(int id)
        {
            var blog = await _dbContext.BlogMaster.FindAsync(id);
            if (blog != null)
            {
                _dbContext.BlogMaster.Remove(blog);
                await _dbContext.SaveChangesAsync();
                return Json(new { success = true });
            }

            return Json(new { success = false, message = "Blog not found" });
        }
    }
}
