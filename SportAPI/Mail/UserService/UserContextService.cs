using Microsoft.AspNetCore.Http;
using SportAPI.Mail.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SportAPI.Mail.UserService
{
    public class UserContextService : IUserContextService 
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ClaimsPrincipal User => _httpContextAccessor.HttpContext?.User;

        public long GetUserId => long.Parse(User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value);
    }
}
