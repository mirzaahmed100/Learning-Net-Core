using Ecommerce.BLL.IUnitOfWork;
using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Ecommerce.Infrastructure.Persistense.Repositories
{
    public class ProductRepository : IGenericRepository<Product>
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Product> _dbSet;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Product>();
        }

        public async Task<Product?> GetById(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Add(Product product)
        {
            _dbSet.Add(product);
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }

        public async Task<List<Product>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<int> Delete(int id)
        {
            var row = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);
            if (row != null)
            {
                _dbSet.Remove(row);
                return 1;
            }
            return 0;
        }


        public async Task<List<Product>> SearchProducts(string searchString)
        {
            string query = "SELECT * FROM Product";

         
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();

                query += " WHERE LOWER(Name) LIKE {0} OR LOWER(Description) LIKE {0}"; //Not paramerized (Sql Injection Can be done)
                string searchPattern = "%" + searchString + "%";
               return _context.Product.FromSqlRaw(query, searchPattern).ToList();
                //return _dbSet.FromSqlRaw(query, searchPattern).ToList();
            }

           
            return _dbSet.FromSqlRaw(query).ToList();
        }

        public Task<List<Product>> SearchAsync(string searchString, Expression<Func<Product, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
    }




