using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.ProductService
{
    public interface IProductService
    {
        public void AddAsync(Product prod);
        public Product Update(Product prod);
        public Task<int> DeleteAsync(int prodId);
        public Task<Product?> GetByID(int prodId);
        public Task<List<Product>> GetAllAsync();

        Task<List<Product>> SearchProducts(string searchString);
    }
}
