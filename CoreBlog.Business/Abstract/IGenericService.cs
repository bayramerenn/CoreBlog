using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.Abstract
{
    public interface IGenericService<TEntity> where TEntity : class
    {
        Task InsertAsync(TEntity blog);
        void Update(TEntity blog);
        void Delete(TEntity blog);
        Task<IEnumerable<TEntity>> GetListAllAsync(Expression<Func<TEntity, bool>> filter = null);

       
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> WhereAsync(Expression<Func<TEntity, bool>> filter);
      
    }
}
