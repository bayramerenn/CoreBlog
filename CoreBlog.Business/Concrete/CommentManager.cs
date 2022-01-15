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
    public class CommentManager : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Comment>> GetListAllAsync(Expression<Func<Comment, bool>> filter = null)
        {
            return await _unitOfWork.Comment.GetListAllAsync(filter);
        }

        public async Task InsertAsync(Comment comment)
        {
            await _unitOfWork.Comment.InsertAsync(comment);
            await _unitOfWork.CommitAsync();
        }
    }
}
