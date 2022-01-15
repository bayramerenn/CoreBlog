using CoreBlog.Business.Abstract;
using CoreBlog.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult PartialAddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<PartialViewResult> PartialAddComment(Comment comment)
        {
            comment.CommentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            comment.BlogID = 1;
            await _commentService.InsertAsync(comment);
            return PartialView();
        }

        public PartialViewResult CommentListByBlog(int id)
        {
            var comments = _commentService.GetListAllAsync(x => x.CommentID == id);
            return PartialView(comments);
        }
    }
}
