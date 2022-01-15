using CoreBlog.Business.Abstract;
using CoreBlog.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace CoreBlog.UI.Controllers
{
    public class NewsLetterController : Controller
    {
        private readonly INewLetterService _newLetterService;

        public NewsLetterController(INewLetterService newLetterService)
        {
            _newLetterService = newLetterService;
        }

        [HttpGet]
        public PartialViewResult SubscribeMail()
        {
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult SubscribeMail(NewsLetter newsLetter)
        {
            newsLetter.MailStatus = true;
            _newLetterService.InsertAsync(newsLetter).Wait();
            return PartialView();
        }
    }
}
