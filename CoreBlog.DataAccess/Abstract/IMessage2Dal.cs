using CoreBlog.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBlog.DataAccess.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        Task<IList<Message2>> GetListWithMessageByReceiverIdSenderWriterAsync(int id);
    }
}
