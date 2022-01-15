using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.Abstract
{
    public interface IBlogService
    {
        Task InsertAsync(Blog blog);
        void Update(Blog blog);
        void Delete(Blog blog);
        Task<IEnumerable<Blog>> GetListAllAsync(Expression<Func<Blog, bool>> filter = null);

        Task<IList<Blog>> GetLastBlogListAsync(int id);
        Task<Blog> GetByIdAsync(int id);
        Task<IList<Blog>> GetBlogListWithCategory(Expression<Func<Blog, bool>> filter = null);
        Task<IList<Blog>> GetBlogListWithWriter(Expression<Func<Blog, bool>> filter = null);
    }
}
