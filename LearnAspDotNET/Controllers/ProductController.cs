using Ecommerce.BLL.ProductService;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductDisplay.Models;

namespace ProductDisplay.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;
        //private readonly ProductService _productService;
        public ProductController(AppDbContext db)
        {
            _dbContext = db;
        }
   
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Index([FromQuery] string SearchString)
        {
            var products = await _dbContext.Product.ToListAsync();
            if(!string.IsNullOrEmpty(SearchString))
            {
                SearchString = SearchString.ToLower();
                products = products.Where(p =>
                    p.Name.ToLower().Contains(SearchString) ||
                    p.Description.ToLower().Contains(SearchString)).ToList();
            }
            return View(products);
        }

       


        //public IActionResult Create()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Create(Product prod)
        //{

        //}

        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _dbContext.Product.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}

