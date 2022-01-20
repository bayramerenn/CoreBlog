using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{
    [AllowAnonymous]
    public class MessageController : Controller
    {
        private readonly IMessage2Service _message2Service;

        public MessageController(IMessage2Service message2Service)
        {
            _message2Service = message2Service;
        }

        public async Task<IActionResult> Inbox()
        {
            var receicerUser = await _message2Service.GetListWithMessageByReceiverIdWriterAsync(2);
            return View(receicerUser);
        }

        public async Task<IActionResult> MessageDetails(int id)
        {
            var result = await _message2Service.GetByIdAsync(id);
            return View(result);
        }
    }
}
