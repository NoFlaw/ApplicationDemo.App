using ApplicationDemo.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationDemo.Data.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDemoContext _context;

        public Repository(AppDemoContext context)
        {
            _context = context;
        }

        public IQueryable<T> GetQuery()
        {
            return _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetQuery().ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = (predicate != null) ? GetQuery().Where(predicate) : GetQuery();
            return await query.ToListAsync();
        }
    }
}
