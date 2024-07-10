using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Business;
using POS.Core.Common;
using POS.Core.Models.Brands;
using POS.Core.Models.Login;
using POS.Core.Models.Register;
using POS.Core.Models.Result;
using System.Net;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IRegisterManager _registerManager;
        private readonly ILoginManager _loginManager;
        public AuthController(IRegisterManager registerManager, ILoginManager loginManager)
        {
            _registerManager = registerManager;
            _loginManager = loginManager;
        }
        [HttpPost("Register")]
        public async Task<ResultModel> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            try
            {
                var RegistResponse = await _registerManager.RegisterAsync(registerModel);

                if (RegistResponse.IsSucceed == true)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.OK,
                        Message = "",
                        Data = RegistResponse
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.InternalServerError,
                        Message = RegistResponse.Message,
                        Data = RegistResponse
                    };
                }

            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = string.Empty
                };
            }
        }
        [HttpPost("Login")]
        public async Task<ResultModel> LoginAsync([FromBody] LoginDto loginmodel)
        {
            try
            {
                var LoginResponse = await _loginManager.LoginAsync(loginmodel);
                if (LoginResponse.IsSucceed == true)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.OK,
                        Message = "",
                        Data = LoginResponse
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.InternalServerError,
                        Message = LoginResponse.Message,
                        Data = LoginResponse
                    };
                }
            }
            catch (Exception ex)
            {
                return new ResultModel()
                {
                    Code = HttpStatusCode.InternalServerError,
                    Message = ex.Message,
                    Data = string.Empty
                };
            }
        }
    }
}
