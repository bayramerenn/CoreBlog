using CoreBlog.Business.Abstract;
using CoreBlog.DataAccess.Context;
using CoreBlog.DataAccess.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
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
