using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<ResultModel> BrandMasterInsertDetails([FromForm] BrandInsertModel brandInsertModel)
        {
            try
            {
                if (brandInsertModel.file == null || brandInsertModel.file.Length ==0)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = Message.CommonFileUploadMsg,
                        Data = string.Empty
                    };
                }
                var extension = Path.GetExtension(brandInsertModel.file.FileName).ToLowerInvariant();
                if (string.IsNullOrEmpty(extension) ||
                    (extension != ".png" && extension != ".jpg" && extension != ".jpeg"))
                  {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = Message.CommonInvalidfiletype,
                        Data = string.Empty
                    };
                }
                var newFileName = Path.GetRandomFileName() + extension;
                var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Uploaded");
                var filePath = Path.Combine(folderPath, newFileName);
                brandInsertModel.BrandImagePath = filePath;
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

