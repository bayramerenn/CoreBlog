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
    public class AboutDal : GenericDal<About>, IAboutDal
    {
        public AppDbContext _appDbContext { get =>  _dbContext as AppDbContext; }
        public AboutDal(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
