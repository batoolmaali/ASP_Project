using Final_Project.Data;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _DbContext;
        public ProductController(AppDbContext dbContext)
        {
            this._DbContext = dbContext;
        }
        public IActionResult Index()
        {
            var products = _DbContext.Products.Include(c => c.Category).ToList();

            var ProductViewModels = products.Select(prod => new ProductViewModel
            {
                Id = prod.Id,
                Name = prod.Name,
                Description = prod.Description,
                Price = prod.Price,
                ImagePath = prod.ImagePath,
                Category = new CategoryViewModel
                {

                    Name = prod.Category.Name
                }
            })
                .ToList();

            return View(ProductViewModels);
        }
    }
}
