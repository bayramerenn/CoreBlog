using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        public async Task<IActionResult> Index()
        {
            var about =await _aboutService.GetListAllAsync();
            return View(about.FirstOrDefault());
        }

        public PartialViewResult SocialMediaAbout()
        {
            return PartialView();
        }
    }
}
