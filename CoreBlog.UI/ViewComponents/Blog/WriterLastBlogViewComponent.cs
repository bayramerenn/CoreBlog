

using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents.Blog
{
    public class WriterLastBlogViewComponent : ViewComponent
    {
        private readonly IBlogService _blogService;

        public WriterLastBlogViewComponent(IBlogService blogService)
        {
            _blogService = blogService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int writerId)
        {
            var result = await _blogService.GetBlogListWithWriter(x => x.WriterID == writerId);
            return View(result);    
        }
    }
}
