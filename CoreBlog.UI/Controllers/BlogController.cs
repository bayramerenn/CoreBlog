using AutoMapper;
using CoreBlog.Business.Abstract;
using CoreBlog.Business.DTOs;
using CoreBlog.DataAccess.Context;
using CoreBlog.DataAccess.Extensions;
using CoreBlog.Entity.Concrete;
using CoreBlog.UI.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CoreBlog.UI.Controllers
{
   
    public class BlogController : Controller
    {
        private readonly IBlogService _blogService;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IUserClaimHelpers _userClaimHelpers;

        private static List<SelectListItem> Categories;
        public BlogController(IBlogService blogService, ICategoryService categoryService, IMapper mapper, IUserClaimHelpers userClaimHelpers)
        {
            _blogService = blogService;
            _categoryService = categoryService;
            _mapper = mapper;
            Categories = GetCategories().Result;
            _userClaimHelpers = userClaimHelpers;
        }

        public async Task<IActionResult> Index()
        {
            
            var blogs = await _blogService.GetBlogListWithCategory();
            return View(blogs);
        }
        public async Task<IActionResult> BlogDetails(int id)
        {
            var blogs = await _blogService.GetBlogListWithCategory(x => x.BlogID == id);
            return View(blogs.FirstOrDefault());
        }

        public async Task<IActionResult> BlogListByWriter()
        {

            var result = await _blogService.GetBlogListWithCategory(x => x.WriterID == _userClaimHelpers.Id);
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> BlogAdd()
        {
            var categories = await _categoryService.GetListAllAsync();

            BlogDto blogDto = new BlogDto
            {
                Category = Categories ?? await GetCategories()
            };
      


            return View(blogDto);  
        }

        [HttpPost]
        public async Task<IActionResult> BlogAdd(BlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {

                blogDto.Category = Categories ?? await GetCategories();

                return View(blogDto);
            }
            blogDto.BlogStatus = true;
            blogDto.BlogCreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            blogDto.WriterID = _userClaimHelpers.Id;
            
            await _blogService.InsertAsync(_mapper.Map<Blog>(blogDto));
            return RedirectToAction("BlogListByWriter","Blog");
           
        }
        public async Task<IActionResult> BlogDelete(int id)
        {
            var blog = await _blogService.GetByIdAsync(id);
             _blogService.Delete(blog);
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        [HttpGet]
        public async Task<IActionResult> EditBlog(int id)
        {
            var blog =await _blogService.GetByIdAsync(id);
            var blogDto = _mapper.Map<BlogDto>(blog);

            blogDto.Category = Categories ?? await GetCategories();
            return View(blogDto);
        }

        [HttpPost]
        public  IActionResult EditBlog(BlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                blogDto.Category = Categories ??  GetCategories().Result;
                return View(blogDto);
            }
            _blogService.Update(_mapper.Map<Blog>(blogDto));
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        public IActionResult Test(BlogDto blogDto)
        {
            if (!ModelState.IsValid)
            {
                blogDto.Category = Categories ?? GetCategories().Result;
                return View(blogDto);
            }
            _blogService.Update(_mapper.Map<Blog>(blogDto));
            return RedirectToAction("BlogListByWriter", "Blog");
        }

        private  async Task<List<SelectListItem>> GetCategories()
        {

            var categories = await _categoryService.GetListAllAsync();

            return categories.Select(x => new SelectListItem
            {
                Text = x.CategoryName,
                Value = x.CategoryID.ToString()
            }).ToList();

        }



        

    }
}
