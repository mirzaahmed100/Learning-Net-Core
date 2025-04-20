using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Ecommerce.BLL.IUnitOfWork;
using Ecommerce.Domain.Entities;
using Ecommerce.Infrastructure.Persistense.Repositories;

namespace Ecommerce.Infrastructure.Persistense
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _repositories = new Dictionary<Type, object>();
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public IRepository<T> GetRepository<T>() where T : class
        {
            if (_repositories.ContainsKey(typeof(T)))
            {
                return (IRepository<T>)_repositories[typeof(T)];
            }

            var repository = new ProductRepository(_context);
            _repositories.Add(typeof(T), repository);
            return (IRepository<T>)repository;
        }


        public void Rollback()
        {
            // when needed it will use
        }
    }
}
