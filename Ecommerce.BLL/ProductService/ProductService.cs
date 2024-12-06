using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure;

namespace Ecommerce.BLL.ProductService
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext context;


       public ProductService(AppDbContext _context)
        {
           context = _context;

        }
        public void AddAsync(Product prod)
        {
            //throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int prodId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        //public Task<List<Product>> GetAllAsync()
        //{
        //    List<Product> allproducts = context.Product.GetAll();
        //}

        public Task<Product?> GetByID(int prodId)
        {
            throw new NotImplementedException();
        }

        public Product Update(Product card)
        {
            throw new NotImplementedException();
        }
    }
}
