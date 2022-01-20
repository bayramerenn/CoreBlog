using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;

namespace CoreBlog.UI.Helpers
{
    public  class UserClaimHelpers: IUserClaimHelpers
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ClaimsPrincipal User;

        public UserClaimHelpers(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            User = _httpContextAccessor.HttpContext.User;
        }

        public int Id { get => int.Parse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value); }
        public string Name { get => _httpContextAccessor.HttpContext.User.Identity.Name; }
        public string Email { get => User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value; }
    }

    public interface IUserClaimHelpers
    {
        public  int Id { get; }
        public  string Name { get;  }
        public  string Email { get; }
    }
}
