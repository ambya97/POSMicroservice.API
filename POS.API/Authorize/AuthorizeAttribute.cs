using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using POS.Core.Common;
using POS.Core.Models.Register;

namespace POS.API.Authorize
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = (GetRegisterModel)context.HttpContext.Items["User"];
            if (user == null)
            {
                // not logged in
                context.Result = new JsonResult(new { message = Message.UnauthorizedMessage, StatusCode = StatusCodes.Status401Unauthorized })
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }
}
