using CoreBlog.DataAccess.Abstract;
using CoreBlog.DataAccess.Concrete;
using CoreBlog.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        private AboutDal _aboutDal;
        private BlogDal _blogDal;
        private CategoryDal _categoryDal;
        private CommentDal _commentDal;
        private ContactDal _contactDal;
        private WriterDal _writerDal;
        private NewsLetterDal _newsLetterDal;
        private NotificationDal _notificationDal;
        private MessageDal _messageDal;
        private Message2Dal _message2Dal;

        public IAboutDal About => _aboutDal = _aboutDal ?? new AboutDal(_appDbContext);

        public IBlogDal Blog => _blogDal = _blogDal ?? new BlogDal(_appDbContext);

        public ICommentDal Comment => _commentDal = _commentDal ?? new CommentDal(_appDbContext);

        public ICategoryDal Category => _categoryDal = _categoryDal ?? new CategoryDal(_appDbContext);

        public IContactDal Contact => _contactDal = _contactDal ?? new ContactDal(_appDbContext);

        public IWriterDal Writer => _writerDal = _writerDal ?? new WriterDal(_appDbContext);

        public INewsLetterDal NewsLetter => _newsLetterDal = _newsLetterDal ?? new NewsLetterDal(_appDbContext);

        public INotificationDal Notification => _notificationDal = _notificationDal ?? new NotificationDal(_appDbContext);

        public IMessageDal Message => _messageDal = _messageDal ?? new MessageDal(_appDbContext);
        public IMessage2Dal Message2 => _message2Dal = _message2Dal ?? new Message2Dal(_appDbContext);

        public void Commit()
        {
            _appDbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _appDbContext.Dispose();
        }
    }
}
