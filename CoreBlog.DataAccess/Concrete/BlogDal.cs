using CoreBlog.DataAccess.Abstract;
using CoreBlog.DataAccess.Context;
using CoreBlog.DataAccess.Extensions;
using CoreBlog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace CoreBlog.DataAccess.Concrete
{
    public class BlogDal:GenericDal<Blog>,IBlogDal
    {
        public AppDbContext appDbContext { get => _dbContext as AppDbContext; }
        public BlogDal(AppDbContext appDbContext):base(appDbContext)
        {

        }

        public async Task<IList<Blog>> GetBlogListWithCategory(Expression<Func<Blog, bool>> filter = null)
        {
            return filter == null ?
                        await appDbContext.Blogs.Include(x => x.Category).ToListAsync() :
                        await appDbContext.Blogs.Include(x => x.Category).Where(filter).ToListAsync();
        }

        public async Task<IList<Blog>> GetBlogListWithWriter(Expression<Func<Blog, bool>> filter = null)
        {
            return filter == null ?
                       await appDbContext.Blogs.Include(x => x.Writer).ToListAsync() :
                       await appDbContext.Blogs.Include(x => x.Writer).Where(filter).ToListAsync();
        }

        public async Task<IList<Blog>> GetLastBlogListAsync(int id)
        {

            var result = await appDbContext.Blogs.Include(x => x.Category).OrderByDescending(o => o.BlogCreatedDate).Take(id).ToListAsync();
            return result;


        }


    }
}
