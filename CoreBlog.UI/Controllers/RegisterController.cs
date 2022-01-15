using CoreBlog.Business.Abstract;
using CoreBlog.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly IWriterService _writerService;

        public RegisterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            if (!ModelState.IsValid)
            {
               
                return View(writer);
            }

            writer.WriterStatus = true;
            writer.WriterAbout = "Deneme";

            await _writerService.InsertAsync(writer);
            return RedirectToAction("Index","Blog");
        }
    }
}
