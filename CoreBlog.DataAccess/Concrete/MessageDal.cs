using CoreBlog.DataAccess.Abstract;
using CoreBlog.DataAccess.Context;
using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.Concrete
{
    public class MessageDal:GenericDal<Message>, IMessageDal
    {
        public AppDbContext _appDbContext { get => _dbContext as AppDbContext; }
        public MessageDal(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
