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
    public class AboutManager : IAboutService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AboutManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<About>> GetListAllAsync(Expression<Func<About, bool>> filter = null)
        {
            return await _unitOfWork.About.GetListAllAsync(filter);
        }
    }
}
