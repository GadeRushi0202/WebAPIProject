using Microsoft.EntityFrameworkCore;
using WebAPIProject.Models;

namespace WebAPIProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categorys { get; set; }

        public DbSet<Register> Registers { get; set; }

        public DbSet<cart> carts { get; set; }

        public DbSet<Orders> Orders { get; set; }
    }
}
