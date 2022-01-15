using CoreBlog.DataAccess.Abstract;
using CoreBlog.DataAccess.Context;
using CoreBlog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.Concrete
{
    public class CategoryDal : GenericDal<Category>, ICategoryDal
    {
        public AppDbContext appDbContext { get => _dbContext as AppDbContext; }
        public CategoryDal(AppDbContext appDbContext) : base(appDbContext)
        {

        }

        public async Task<IList<Category>> GetCategoryListWithBlog(Expression<Func<Category, bool>> filter = null)
        {
            return filter == null ?
                await appDbContext.Categories.Include(x => x.Blogs).ToListAsync() :
                 await appDbContext.Categories.Include(x => x.Blogs).Where(filter).ToListAsync();
        }
    }
}
