using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.UI.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
