using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{

    public class DashboardController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;

        public DashboardController(IBlogService blogService, ICategoryService categoryService)
        {
            _blogService = blogService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetListAllAsync();
            ViewBag.TotalBlogCount = blogs.Count();
            ViewBag.TotalWriterByIdCount = blogs.Where(x => x.WriterID == 2).Count();
            ViewBag.TotalCategoryCount = _categoryService.GetListAllAsync().Result.Count();
            return View();
        }
    }
}
