using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents.Blog
{
    
    public class FooterLastBlogsViewComponent:ViewComponent
    {
        private readonly IBlogService _blogService;

        public FooterLastBlogsViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var result = await _blogService.GetLastBlogListAsync(3);
            return View(result);    
        }
    }
}
