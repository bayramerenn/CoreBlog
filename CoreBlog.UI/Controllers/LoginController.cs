using CoreBlog.Business.Abstract;
using CoreBlog.Entity.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IWriterService _writerService;

        public LoginController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Writer writer)
        {
            var result = await _writerService.WhereAsync(x => x.WriterMail == writer.WriterMail && x.WriterPassword == writer.WriterPassword);
            if (result != null)
            {
                var claims = new List<Claim>
               {
                   new Claim(ClaimTypes.Email,result.WriterMail),
                   new Claim(ClaimTypes.NameIdentifier,result.WriterID.ToString()),
                   new Claim(ClaimTypes.Name,result.WriterName)
               };
                var userIdentity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index", "Dashboard");
            }

            return View();
        }

        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
