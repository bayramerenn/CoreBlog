using AutoMapper;
using CoreBlog.Business.Abstract;
using CoreBlog.Business.DTOs;
using CoreBlog.Entity.Concrete;
using CoreBlog.UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{

    public class WriterController : Controller
    {
        private readonly IWriterService _writerService;
        private readonly IMapper _mapper;
        private readonly IUserClaimHelpers _userClaimHelpers;

  
        public WriterController(IWriterService writerService, IMapper mapper, IUserClaimHelpers userClaimHelpers)
        {
            _writerService = writerService;
            _mapper = mapper;
            _userClaimHelpers = userClaimHelpers;
        }

        public IActionResult Index()
        {
            ViewBag.Id = _userClaimHelpers.Id.ToString();
            ViewBag.Email = _userClaimHelpers.Email;
            return View();
        }

        public PartialViewResult WriterNavbarPartial()
        {
            return PartialView();
        }
        public PartialViewResult WriterFooterPartial()
        {
            return PartialView();
        }

        [HttpGet]
        public async Task<IActionResult> WriterEditProfile()
        {
            var writer = await _writerService.GetByIdAsync(_userClaimHelpers.Id);
            ViewBag.WriterImage = writer.WriterImage;
            return View(_mapper.Map<WriterDto>(writer));
        }

        [HttpPost]
        public IActionResult WriterEditProfile(WriterDto writerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(writerDto);
            }

              _writerService.Update(_mapper.Map<Writer>(writerDto));
            return RedirectToAction("Index","Dashboard");
        }

        [HttpGet]
        public IActionResult WriterAdd()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WriterAdd(WriterDto writerDto)
        
        {
            var writer = _mapper.Map<Writer>(writerDto);
            if (!ModelState.IsValid)
            {
                return View(writerDto);
            }

            await _writerService.InsertAsync(writer);
            return RedirectToAction("Index", "Dashboard");
        }


    }
}
