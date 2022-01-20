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

        public void Delete(Writer blog)
        {
            throw new NotImplementedException();
        }

        public async Task<Writer> GetByIdAsync(int id)
        {
            return await _unitOfWork.Writer.GetByIdAsync(id);
        }

        public Task<IEnumerable<Writer>> GetListAllAsync(Expression<Func<Writer, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public async Task InsertAsync(Writer writer)
        {
            await _unitOfWork.Writer.InsertAsync(writer);
            await _unitOfWork.CommitAsync();
        }

        public void Update(Writer blog)
        {
            _unitOfWork.Writer.Update(blog);
            _unitOfWork.Commit();
        }

        public async Task<Writer> WhereAsync(Expression<Func<Writer, bool>> filter = null)
        {
            var result = await _unitOfWork.Writer.GetListAllAsync(filter);
            return result.FirstOrDefault();
        }
    }
}
