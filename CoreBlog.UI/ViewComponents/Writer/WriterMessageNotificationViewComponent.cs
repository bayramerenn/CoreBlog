using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents.Writer
{
    public class WriterMessageNotificationViewComponent:ViewComponent
    {
        private readonly IMessage2Service _message2Service;

        public WriterMessageNotificationViewComponent(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var message = await _message2Service.GetListWithMessageByReceiverIdWriterAsync(2);
            return View(message);
        }
    }
}
