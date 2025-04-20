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
        private readonly IProductService _productService;
        //private readonly ProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
   


       
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Product>>> Index([FromQuery] string SearchString)
        //{
        //    var products = await _dbContext.Product.ToListAsync();
        //    if(!string.IsNullOrEmpty(SearchString))
        //    {
        //        SearchString = SearchString.ToLower();
        //        products = products.Where(p =>
        //            p.Name.ToLower().Contains(SearchString) ||
        //            p.Description.ToLower().Contains(SearchString)).ToList();
        //    }
        //    return View(products);
        //}




        [HttpPost]
        public IActionResult Search(string searchString)
        {
            
            return RedirectToAction("Search", "Search", new { searchString = searchString });
        }

        //[HttpGet]
        //public IActionResult Details(int id)
        //{
        //    var product = _dbContext.Product.FirstOrDefault(p => p.Id == id);
        //    if (product == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product);
        //}

        [HttpGet]
        public IActionResult Home()
        {
            return View();
        }



    }
}

