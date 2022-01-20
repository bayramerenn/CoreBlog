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
    public class NotificationDal : GenericDal<Notification>, INotificationDal
    {
        public AppDbContext appDbContext { get => _dbContext as AppDbContext;  }
        public NotificationDal(AppDbContext dbContext) : base(dbContext)
        {
        }

    }
}
