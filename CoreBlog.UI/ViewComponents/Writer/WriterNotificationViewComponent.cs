using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents.Writer
{
    public class WriterNotificationViewComponent : ViewComponent
    {
        private readonly INotificationService _notificationService;

        public WriterNotificationViewComponent(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notification = await _notificationService.GetListAllAsync();
            return View(notification);
        }
    }
}
