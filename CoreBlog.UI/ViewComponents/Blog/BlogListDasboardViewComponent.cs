using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents.Blog
{
    public class BlogListDasboardViewComponent:ViewComponent
    {
        private readonly IBlogService _blogService;

        public BlogListDasboardViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _blogService.GetLastBlogListAsync(10);
            return View(result);
        }
    }
}
