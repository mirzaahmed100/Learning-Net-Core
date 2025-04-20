using Ecommerce.BLL.ProductService;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnAspDotNET.Controllers
{
    public class SearchController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly IProductService _productService;
        public SearchController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public async Task<IActionResult> Search(string searchString)
        {
            if (string.IsNullOrEmpty(searchString))
            {
                return NotFound("Search cannot be null or empty.");
            }

            var products = await _productService.SearchProducts(searchString);
           
            return View(products);
        }
    }
}
