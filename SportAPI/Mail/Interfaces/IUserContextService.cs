using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SportAPI.Mail.Interfaces
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        long GetUserId { get; }
    }
}
