using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents.Notification
{
    public class NotificationListViewComponent:ViewComponent
    {
        private readonly INotificationService _notificationService;

        public NotificationListViewComponent(INotificationService notificationService)
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
