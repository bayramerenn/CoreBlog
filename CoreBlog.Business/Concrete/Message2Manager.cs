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
    public class Message2Manager : IMessage2Service
    {
        private readonly IUnitOfWork _unitOfWork;

        public Message2Manager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Delete(Message2 blog)
        {
            _unitOfWork.Message2.Delete(blog);
            _unitOfWork.Commit();
        }

        public async Task<Message2> GetByIdAsync(int id)
        {
            return await _unitOfWork.Message2.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Message2>> GetListAllAsync(Expression<Func<Message2, bool>> filter = null)
        {
            return await _unitOfWork.Message2.GetListAllAsync(filter);
        }

        public async Task<IList<Message2>> GetListWithMessageByReceiverIdWriterAsync(int id)
        {
            return await _unitOfWork.Message2.GetListWithMessageByReceiverIdSenderWriterAsync(id);
        }

        public async Task InsertAsync(Message2 blog)
        {
           await _unitOfWork.Message2.InsertAsync(blog);
            await _unitOfWork.CommitAsync();
        }

        public void Update(Message2 blog)
        {
             _unitOfWork.Message2.Update(blog);
             _unitOfWork.Commit();
        }

        public async Task<Message2> WhereAsync(Expression<Func<Message2, bool>> filter)
        {
            return await _unitOfWork.Message2.WhereAsync(filter);
        }
    }
}
