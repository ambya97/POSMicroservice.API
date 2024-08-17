using POS.Core.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Authentication
{
    public interface IAuthenticationService
    {
        TokenResponseDto GenerateNewJsonWebToken(List<Claim> claims);
        string GetUserIdFromToken(string token);
    }
}
