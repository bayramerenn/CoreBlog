using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.Abstract
{
    public interface IAboutService
    {
        Task<IEnumerable<About>> GetListAllAsync(Expression<Func<About, bool>> filter = null);
    }
}
