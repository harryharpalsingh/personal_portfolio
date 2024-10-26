using harryisdev.Data;
using harryisdev.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        //Get
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blogFromDb = await _dbContext.BlogMaster
                .FirstOrDefaultAsync(b => b.Id == id);

            if (blogFromDb == null)
            {
                return NotFound();
            }

            // Truncate BlogData to a specified length, e.g., 200 characters
            //const int maxLength = 200; // Adjust as needed
            //blogFromDb.BlogData = TruncateHtml(blogFromDb.BlogData, maxLength);

            return View(blogFromDb);
        }

        private string TruncateHtml(string html, int maxLength)
        {
            if (string.IsNullOrEmpty(html) || html.Length <= maxLength)
            {
                return html;
            }

            // Truncate and ensure to close any open tags
            var truncated = html.Substring(0, maxLength);

            // Check if the last character is an opening tag
            int lastOpenTagIndex = truncated.LastIndexOf("<");
            int lastCloseTagIndex = truncated.LastIndexOf(">");

            if (lastOpenTagIndex > lastCloseTagIndex)
            {
                truncated = truncated.Substring(0, lastOpenTagIndex); // Remove the incomplete tag
            }

            return truncated + "..."; // Add ellipsis to indicate truncation
        }

    }
}
