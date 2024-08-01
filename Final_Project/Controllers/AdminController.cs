using Final_Project.Data;
using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Final_Project.Controllers
{
    public class AdminController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _DbContext;
        public AdminController(AppDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this._DbContext = dbContext;
            this._webHostEnvironment = webHostEnvironment;
        }

        #region Products

        //Get All Product
        [HttpGet]
        public IActionResult Dashboard()
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

        // Get Products Form
        [HttpGet]
        public IActionResult Products()
        {

            ViewBag.Cat = _DbContext.Categories.ToList();
            return View();

        }

        // Create New Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductViewModel viewModel, IFormFile Image)
        {
            try
            {

                var product = new Product();
                if (viewModel != null)
                {
                    if (Image != null)
                    {
                        string folder = "Images/ProductsImages";
                        string fileName = Guid.NewGuid().ToString() + Path.GetExtension(Image.FileName);
                        string filePath = Path.Combine(_webHostEnvironment.WebRootPath, folder, fileName);

                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            Image.CopyTo(stream);
                        }


                        product.ImagePath = Path.Combine(folder, fileName);
                        product.Id = viewModel.Id;
                        product.Name = viewModel.Name;
                        product.Description = viewModel.Description;
                        product.Price = viewModel.Price;
                        product.CategoryId = viewModel.CategoryId;

                        _DbContext.Products.Add(product);
                        _DbContext.SaveChanges();
                        return RedirectToAction(nameof(Dashboard));
                    }
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        //Delete Product
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteProd(int id, ProductViewModel model)
        {
            try
            {
                var item = _DbContext.Products.Where(x => x.Id == id).FirstOrDefault();
                if (item != null)
                {
                    _DbContext.Remove(item);
                    _DbContext.SaveChanges();
                    return RedirectToAction(nameof(Dashboard));

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        #endregion


        #region Category
        //Get All Categories
        [HttpGet]
        public IActionResult Categories()
        {
            var Cats = _DbContext.Categories.ToList();

            var CatViewModels = Cats.Select(cat => new CategoryViewModel
            {
                Id = cat.Id,
                Name = cat.Name,

            }).ToList();

            return View(CatViewModels);

        }

        // Get Category Form
        [HttpGet]
        public ActionResult CreateCat()
        {

            return View();

        }
        // Create New Category
        [HttpPost]
        public ActionResult CreateCategory(CategoryViewModel viewModel)
        {

            var cat = new Category();
            if (viewModel != null)
            {

                cat.Id = viewModel.Id;
                cat.Name = viewModel.Name;

                _DbContext.Categories.Add(cat);
                _DbContext.SaveChanges();
                return RedirectToAction(nameof(Categories));

            }
            return View();
        }

        //Delete Category
        [HttpPost]
        public IActionResult DeleteCat(int id, CategoryViewModel model)
        {
            try
            {
                var item = _DbContext.Categories.Where(x => x.Id == id).FirstOrDefault();
                if (item != null)
                {
                    _DbContext.Remove(item);
                    _DbContext.SaveChanges();
                    return RedirectToAction(nameof(Categories));

                }
                return View();
            }
            catch
            {
                return View();
            }
        }
        #endregion


    }
}
