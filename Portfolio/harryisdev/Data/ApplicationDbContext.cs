using harryisdev.Models;
using Microsoft.EntityFrameworkCore;

namespace harryisdev.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<BlogMaster> BlogMaster { get; set; }
    }
}
