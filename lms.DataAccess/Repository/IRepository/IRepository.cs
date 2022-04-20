using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace lms.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        // T - Category 
         T GetFirstOrDefault(Expression<Func<T,bool>> filter);// we have handled this get first our default scenario 
         IEnumerable<T> GetAll();
         void Add(T entity);

    }
}
