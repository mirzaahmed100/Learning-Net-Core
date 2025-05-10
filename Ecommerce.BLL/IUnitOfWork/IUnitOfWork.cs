using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.BLL.IUnitOfWork
{
    public interface IUnitOfWork
    {
        void Commit();
        void Rollback();
        //IRepository<T> GetRepository<T>() where T : class;
    }
}
