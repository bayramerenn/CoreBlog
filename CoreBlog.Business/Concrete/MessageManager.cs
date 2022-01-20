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
    public class MessageManager : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Delete(Message blog)
        {
            _unitOfWork.Message.Delete(blog);
            _unitOfWork.Commit();
        }

        public async Task<Message> GetByIdAsync(int id)
        {
            return await _unitOfWork.Message.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Message>> GetListAllAsync(Expression<Func<Message, bool>> filter = null)
        {
            return await _unitOfWork.Message.GetListAllAsync(filter);
        }

        public async Task InsertAsync(Message blog)
        {
           await _unitOfWork.Message.InsertAsync(blog);
            await _unitOfWork.CommitAsync();
        }

        public void Update(Message blog)
        {
             _unitOfWork.Message.Update(blog);
             _unitOfWork.Commit();
        }

        public async Task<Message> WhereAsync(Expression<Func<Message, bool>> filter)
        {
            return await _unitOfWork.Message.WhereAsync(filter);
        }
    }
}
