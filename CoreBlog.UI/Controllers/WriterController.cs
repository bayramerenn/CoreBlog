using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.UI.Controllers
{
    public class WriterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
