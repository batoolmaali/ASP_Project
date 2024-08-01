using Final_Project.Models;
using Microsoft.EntityFrameworkCore;
using Final_Project.ViewModels;

namespace Final_Project.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Final_Project.ViewModels.CategoryViewModel> CategoryViewModel { get; set; } = default!;
        public DbSet<Final_Project.ViewModels.ProductViewModel> ProductViewModel { get; set; } = default!;
        
    }
}
