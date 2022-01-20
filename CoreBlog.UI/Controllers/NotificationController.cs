using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{
    [AllowAnonymous]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AllNotification()
        {
            var notification = await _notificationService.GetListAllAsync();
            return View(notification);
        }
    }
}
