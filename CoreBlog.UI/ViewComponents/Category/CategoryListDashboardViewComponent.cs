using CoreBlog.Business.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents.Category
{
    public class CategoryListDashboardViewComponent: ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryListDashboardViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _categoryService.GetListAllAsync();
            return View(categories);
        }
    }
}
