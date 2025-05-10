using Ecommerce.BLL.IUnitOfWork;
using Ecommerce.Domain.Entities;

namespace Ecommerce.BLL.ProductService
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork.IUnitOfWork _unitOfWork;
         private readonly IRepository<Product> _prodRepository;


        public ProductService(IUnitOfWork.IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _prodRepository = (IRepository<Product>?)_unitOfWork.GetRepository<Product>();

        }
        public void AddAsync(Product prod)
        {
            _prodRepository.Add(prod);
            _unitOfWork.Commit();
        }

        public async Task<int> DeleteAsync(int prodId)
        {
            var numberOfRow = await _prodRepository.Delete(prodId);
            if (numberOfRow < 0)
            {
                _unitOfWork.Commit();
            }
            return numberOfRow;
        }

        public Task<List<Product>> GetAllAsync()
        {
            return _prodRepository.GetAll();
        }

        

        //public Task<List<Product>> GetAllAsync()
        //{
        //    List<Product> allproducts = context.Product.GetAll();
        //}

        public Task<Product?> GetByID(int prodId)
        {
            return _prodRepository.GetById(prodId);
        }

        

        public Product Update(Product prod)
        {
            _prodRepository.Update(prod);
            _unitOfWork.Commit();
            return prod;
        }
    }
}
