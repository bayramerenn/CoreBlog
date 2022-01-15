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
    public class CategoryManager : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Category category)
        {
            _unitOfWork.Category.Delete(category);
            _unitOfWork.Commit();
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            return await _unitOfWork.Category.GetByIdAsync(id);
        }

        public async Task<IList<Category>> GetCategoryListWithBlog(Expression<Func<Category, bool>> filter = null)
        {
            return await _unitOfWork.Category.GetCategoryListWithBlog(filter);
        }

        public async Task<IEnumerable<Category>> GetListAllAsync(Expression<Func<Category, bool>> filter = null)
        {
            return await _unitOfWork.Category.GetListAllAsync(filter);
        }

        public async Task InsertAsync(Category category)
        {
            await _unitOfWork.Category.InsertAsync(category);
            await _unitOfWork.CommitAsync();
        }

        public void Update(Category category)
        {
            _unitOfWork.Category.Update(category);
            _unitOfWork.Commit();
        }
    }
}
