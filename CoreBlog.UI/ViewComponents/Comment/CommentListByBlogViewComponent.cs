using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents
{
    public class CommentListByBlogViewComponent:ViewComponent
    {
        private readonly ICommentService _commentService;

        public CommentListByBlogViewComponent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            var comments = await _commentService.GetListAllAsync(x => x.BlogID == id);
            return View(comments);
        }
    }
}
