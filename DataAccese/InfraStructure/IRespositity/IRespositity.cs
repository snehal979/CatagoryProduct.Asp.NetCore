using AppModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.IRespositity
{
    public interface IRespositity<T> where T : class
    {
       //index -list
         IEnumerable<T> GetAll();

        //Details
        T GetT(Expression<Func<T,bool>> predicate);

        //Create
         void Add(T entity);

        //Delete
         void Delete(T entity);

        //Update-Edit
         void DeleteRange(IEnumerable<T> entity);
    }
}
