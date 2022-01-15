using CoreBlog.Business.Abstract;
using CoreBlog.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            contact.ContactDate = DateTime.Parse(DateTime.Now.Date.ToShortDateString());
            contact.ContactStatus = true;
            await _contactService.InsertAsync(contact);
            return RedirectToAction("Index","Blog");
        }
    }
}
