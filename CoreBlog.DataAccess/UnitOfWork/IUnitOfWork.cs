using CoreBlog.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.UnitOfWork
{
    public interface IUnitOfWork
    {
        IAboutDal About { get; }
        IBlogDal Blog { get; }
        ICommentDal Comment { get; }    
        ICategoryDal Category { get; }
        IContactDal Contact { get; }
        IWriterDal Writer { get; }
        INewsLetterDal NewsLetterDal { get; }

        Task CommitAsync();
        void Commit();
        void Dispose();
    }
}
