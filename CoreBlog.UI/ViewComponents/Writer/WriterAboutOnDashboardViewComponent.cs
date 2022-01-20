using CoreBlog.Business.Abstract;
using CoreBlog.UI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreBlog.UI.ViewComponents.Writer
{
    public class WriterAboutOnDashboardViewComponent: ViewComponent
    {
        private readonly IWriterService _writerService;
        private readonly IUserClaimHelpers _userClaimHelpers;

        public WriterAboutOnDashboardViewComponent(IWriterService writerService, IUserClaimHelpers userClaimHelpers)
        {
            _writerService = writerService;
            _userClaimHelpers = userClaimHelpers;
        }
        public async  Task<IViewComponentResult> InvokeAsync()
        {
            int id = _userClaimHelpers.Id;
            var writer = await _writerService.GetByIdAsync(id);
            return View(writer);
        }
    }
}
