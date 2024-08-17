using POS.Business.Authentication;
using POS.Core.Models.Login;
using POS.Core.Models.Register;
using POS.Core.Models.Result;
using POS.Core.Models.Roleclaims;
using POS.Core.Models.User;
using POS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using static POS.Core.Enum.StaticUserRoles;

namespace POS.Business
{
    public class LoginManager : ILoginManager
    {
        private readonly ILoginService _loginService;
        private readonly IAuthenticationService _authenticationService;
         public LoginManager(ILoginService loginService,IAuthenticationService authenticationService)
        {
            _loginService = loginService;
            _authenticationService = authenticationService;
        }

        public async Task<UserModel> GetUserById(int userId)
        {
            return await _loginService.GetUserById(userId);
        }

        public async Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto)
        {
            var isExistsUser = await _loginService.FindByEmailDetails(loginDto.Email);
            if (isExistsUser is null)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid Credentials"
                };
            bool verify = BCrypt.Net.BCrypt.Verify(loginDto.Password, isExistsUser?.PasswordHash);
            if (!verify)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid Credentials"
                };
            var UserRole = await _loginService.GetRolesAsync(isExistsUser.UserId);
            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, isExistsUser.Email),
                new Claim(ClaimTypes.NameIdentifier, isExistsUser.UserId.ToString()),
                new Claim("JWTID", Guid.NewGuid().ToString()),
                new Claim("FirstName", isExistsUser.FirstName),
                new Claim("LastName", isExistsUser.LastName),
            };
            authClaims.Add(new Claim(ClaimTypes.Role, UserRole.RoleName));
            var token= _authenticationService.GenerateNewJsonWebToken(authClaims);
            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = token.Token,
                ExpireDate=token.ExpireDate,
            };
        }
    }
}
