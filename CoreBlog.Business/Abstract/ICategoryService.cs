using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.Abstract
{
    public interface ICategoryService
    {
        Task InsertAsync(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task<IEnumerable<Category>> GetListAllAsync(Expression<Func<Category, bool>> filter = null);
        Task<Category> GetByIdAsync(int id);
        Task<IList<Category>> GetCategoryListWithBlog(Expression<Func<Category, bool>> filter = null);
    }
}
