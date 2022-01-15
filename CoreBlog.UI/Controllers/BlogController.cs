using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            var blogs = await _blogService.GetBlogListWithCategory();
            return View(blogs);
        }
        public async Task<IActionResult> BlogDetails(int id)
        {
            var blogs = await _blogService.GetBlogListWithCategory(x => x.BlogID == id);
            return View(blogs.FirstOrDefault());
        }
    }
}
