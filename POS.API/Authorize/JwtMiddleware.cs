using Microsoft.AspNetCore.Identity;
using POS.Business;
using POS.Business.Authentication;
using System.Security.Claims;
using static POS.Core.Common.StaticValues;

namespace POS.API.Authorize
{
    public class JwtMiddleware
    {
        #region Global  Variables
        private readonly RequestDelegate _next;
        #endregion

        #region Ctor
        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Get Token from Header which is passed in API
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="usersManager">IUsersManager</param>
        /// <param name="authenticationService">IAuthenticationService</param>
        public async Task Invoke(HttpContext context,
            ILoginManager usersManager, IAuthenticationService authenticationService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                await AttachUserToContext(context, usersManager, token, authenticationService);

            await _next(context);
        }

        /// <summary>
        /// Validate Token and Set User Model into Context
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="usersManager">IUsersManager</param>
        /// <param name="token">string</param>
        /// <param name="authenticationService">IAuthenticationService</param>
        private async Task AttachUserToContext(HttpContext context,
            ILoginManager usersManager, string token, IAuthenticationService authenticationService)
        {
            try
            {
                // Call service and get user id from claim
                var userId = authenticationService.GetUserIdFromToken(token);

                // attach user to context on successful jwt validation
                context.Items["User"] = await usersManager.GetUserById(Convert.ToInt32(userId));
                context.Items[Claims.UserId] = Convert.ToInt32(userId);
                context.Items[Claims.AuthorizeToken] = token;
            }
            catch
            {
                // do nothing if jwt validation fails
                // user is not attached to context so request won't have access to secure routes
            }
        }
        #endregion
    }
}
