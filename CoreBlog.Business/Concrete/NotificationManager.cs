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
    public class NotificationManager : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Delete(Notification blog)
        {
            _unitOfWork.Notification.Delete(blog);
            _unitOfWork.Commit();
        }

        public async Task<Notification> GetByIdAsync(int id)
        {
            return await _unitOfWork.Notification.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Notification>> GetListAllAsync(Expression<Func<Notification, bool>> filter = null)
        {
           return await _unitOfWork.Notification.GetListAllAsync(filter);
        }

        public async Task InsertAsync(Notification blog)
        {
            await _unitOfWork.Notification.InsertAsync(blog);
            await _unitOfWork.CommitAsync();
        }

        public void Update(Notification blog)
        {
            _unitOfWork.Notification.Update(blog);
            _unitOfWork.Commit();
        }

        public async Task<Notification> WhereAsync(Expression<Func<Notification, bool>> filter)
        {
            return await _unitOfWork.Notification.WhereAsync(filter);   
        }
    }
}
