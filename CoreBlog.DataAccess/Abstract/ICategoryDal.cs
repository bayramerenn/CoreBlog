using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.Abstract
{
    public interface ICategoryDal : IGenericDal<Category>
    {
        Task<IList<Category>> GetCategoryListWithBlog(Expression<Func<Category, bool>> filter = null);
    }
}
