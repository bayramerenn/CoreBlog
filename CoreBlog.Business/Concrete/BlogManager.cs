using CoreBlog.Business.Abstract;
using CoreBlog.DataAccess.UnitOfWork;
using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Blog blog)
        {
            _unitOfWork.Blog.Delete(blog);
            _unitOfWork.Commit();
        }

        public Task<IList<Blog>> GetBlogListWithCategory(Expression<Func<Blog, bool>> filter = null)
        {
            return _unitOfWork.Blog.GetBlogListWithCategory(filter);
        }

        public async Task<IList<Blog>> GetBlogListWithWriter(Expression<Func<Blog, bool>> filter = null)
        {
            return await _unitOfWork.Blog.GetBlogListWithWriter(filter);
        }

        public async Task<Blog> GetByIdAsync(int id)
        {
           return await _unitOfWork.Blog.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Blog>> GetListAllAsync(Expression<Func<Blog, bool>> filter = null)
        {
            return await _unitOfWork.Blog.GetListAllAsync(filter);
        }

        public async Task InsertAsync(Blog blog)
        {
            await _unitOfWork.Blog.InsertAsync(blog);
            await _unitOfWork.CommitAsync();
        }

        public void Update(Blog blog)
        {
            _unitOfWork.Blog.Update(blog);
            _unitOfWork.Commit();
        }
    }
}
