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
    public class NewsLetterDal : GenericDal<NewsLetter>, INewsLetterDal
    {
        public AppDbContext appDbContext { get => _dbContext as AppDbContext; }
        public NewsLetterDal(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
