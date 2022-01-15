using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.Abstract
{
    public interface ICommentService
    {
        Task InsertAsync(Comment comment);
      
        Task<IEnumerable<Comment>> GetListAllAsync(Expression<Func<Comment, bool>> filter = null);
       
    }
}
