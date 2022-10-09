using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace ClassBook.Api.Authorization
{
    public class GetUserClaim
    {
        private readonly IActionContextAccessor _actionContextAccessor;
        public GetUserClaim(IActionContextAccessor actionContextAccessor)
        {
            _actionContextAccessor = actionContextAccessor;
        }

        public string GetEmail()
        {
            return _actionContextAccessor.ActionContext.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;
        }
    }
}
