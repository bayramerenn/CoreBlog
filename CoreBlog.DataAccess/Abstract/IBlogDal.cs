using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        Task<IList<Blog>> GetBlogListWithCategory(Expression<Func<Blog, bool>> filter = null);
        Task<IList<Blog>> GetBlogListWithWriter(Expression<Func<Blog, bool>> filter = null);
    }
}
