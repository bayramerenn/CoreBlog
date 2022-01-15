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
    public class WriterManager : IWriterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public WriterManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InsertAsync(Writer writer)
        {
            await _unitOfWork.Writer.InsertAsync(writer);
            await _unitOfWork.CommitAsync();
        }

        public async Task<Writer> WhereAsync(Expression<Func<Writer, bool>> filter = null)
        {
            var result = await _unitOfWork.Writer.GetListAllAsync(filter);
            return result.FirstOrDefault();
        }
    }
}
