using CoreBlog.DataAccess.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.Concrete
{
    public class GenericDal<TEntity> : IGenericDal<TEntity> where TEntity : class
    {
        public readonly DbContext _dbContext;
        private DbSet<TEntity> _dbSet;
        public GenericDal(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>(); 
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetListAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            return  filter == null ?
                       await _dbSet.ToListAsync() :
                       await _dbSet.Where(filter).ToListAsync();
        }

        public async Task InsertAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);    
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
