using Ecommerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.IUnitOfWork
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> GetById(int id);
        public void Add(T entity);
        public void Update(T entity);
        public Task<List<T>> GetAll();
        Task<int> Delete(int id);
        Task<List<T>> SearchAsync(string searchString, Expression<Func<T, bool>> predicate);
    }
}
