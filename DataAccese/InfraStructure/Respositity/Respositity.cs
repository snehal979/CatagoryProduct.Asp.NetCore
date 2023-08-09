using AppModel;
using DataAccese.Data;
using DataAccese.IRespositity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccese.InfraStructure.Respositity
{
    public class Respositity<T> : IRespositity<T> where T : class
    {
        private AppDbContext _context;
        private DbSet<T> _dbSet;
       
        public Respositity(AppDbContext context)
        {
            _context=context;
            _dbSet =_context.Set<T>();
        }
        public IEnumerable<T> GetAll()
        {
           return _dbSet.ToList();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void DeleteRange(IEnumerable<T> entity)
        {
            _dbSet.RemoveRange(entity);
        }

   
        public T GetT(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate).FirstOrDefault();
        }
    }
}
