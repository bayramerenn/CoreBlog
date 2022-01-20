using CoreBlog.DataAccess.Abstract;
using CoreBlog.DataAccess.Context;
using CoreBlog.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.Concrete
{
    public class Message2Dal : GenericDal<Message2>, IMessage2Dal
    {
        public AppDbContext _appDbContext { get => _dbContext as AppDbContext; }
        public Message2Dal(AppDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IList<Message2>> GetListWithMessageByReceiverIdSenderWriterAsync(int id)
        {
            return await _appDbContext.Messages2.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToListAsync();
        }
    }
}
