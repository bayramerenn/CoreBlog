using CoreBlog.Business.Abstract;
using CoreBlog.DataAccess.UnitOfWork;
using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.Business.Concrete
{
    public class NewsLetterManager : INewLetterService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsLetterManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task InsertAsync(NewsLetter newsLetter)
        {
            await _unitOfWork.NewsLetterDal.InsertAsync(newsLetter);
            await _unitOfWork.CommitAsync();
        }
    }
}
