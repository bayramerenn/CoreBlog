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
    public class ContactDal : GenericDal<Contact>, IContactDal
    {
        public AppDbContext appDbContext { get => _dbContext as AppDbContext; }
        public ContactDal(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}
