using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Business;
using POS.Core.Common;
using POS.Core.Models.Brands;
using POS.Core.Models.Result;
using System.Net;

namespace POS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        #region Global Variable
        private readonly IBrandManager _brandManager;
        #endregion
        public BrandController(IBrandManager brandManager)
        {
            _brandManager = brandManager;
        }
        [HttpPost("BrandMasterInsertDetails")]
        public async Task<ResultModel> BrandMasterInsertDetails([FromBody] BrandInsertModel brandInsertModel)
        {
            try
            {
                int responseid = await _brandManager.BrandMasterInsertDetails(brandInsertModel);
                if (responseid == 0)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.Found,
                        Message = Message.UnitTypeAleradyExist,
                        Data = responseid
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.OK,
                        Message = Message.CommonInsertMessage,
                        Data = responseid
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

