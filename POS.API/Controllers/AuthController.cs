using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Business;
using POS.Core.Common;
using POS.Core.Models.Brands;
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
        public AuthController(IRegisterManager registerManager)
        {
            _registerManager = registerManager;
        }
        [HttpPost("Register")]
        public async Task<ResultModel> RegisterAsync([FromBody] RegisterModel registerModel)
        {
            try
            {
                var RegistResponse= await _registerManager.RegisterAsync(registerModel);
               
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
            catch (Exception ex) {
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
