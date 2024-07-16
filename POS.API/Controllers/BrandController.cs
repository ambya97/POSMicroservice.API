using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using POS.API.Helpers;
using POS.Business;
using POS.Core.Common;
using POS.Core.Enum;
using POS.Core.Models.Brands;
using POS.Core.Models.Result;
using POS.Core.Models.Unit;
using System.Net;

namespace POS.API.Controllers
{
    [Authorize(Roles = StaticRoles.ADMIN)]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        #region Global Variable
        private readonly IBrandManager _brandManager;
        private readonly IFileUploadHelper _fileUploadHelper;
        #endregion
        public BrandController(IBrandManager brandManager, IFileUploadHelper fileUploadHelper)
        {
            _brandManager = brandManager;
            _fileUploadHelper = fileUploadHelper;
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
                string originalFileName = Path.GetFileName(brandInsertModel.file.FileName);
                string physicalFileName = _fileUploadHelper.GetUniqueFileName(originalFileName);
                string physicalFolderPath = _fileUploadHelper.GetUsersFolderPath(true);
                string physicalFileFullPath = Path.Combine(physicalFolderPath, physicalFileName);
                if (!Directory.Exists(physicalFolderPath))
                {
                    Directory.CreateDirectory(physicalFolderPath);
                }
                using var stream = System.IO.File.Create(physicalFileFullPath);
                // Upload File
                await brandInsertModel.file.CopyToAsync(stream);
                brandInsertModel.BrandImagePath = physicalFileFullPath;
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

        [HttpPost("BrandMasterUpdateDetails")]
        public async Task<ResultModel> BrandMasterUpdateDetails([FromForm] UpdateBrandModel updateBrandModel)
        {
            try
            {
                if (updateBrandModel.file == null || updateBrandModel.file.Length == 0)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.BadRequest,
                        Message = Message.CommonFileUploadMsg,
                        Data = string.Empty
                    };
                }
                var extension = Path.GetExtension(updateBrandModel.file.FileName).ToLowerInvariant();
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
                string originalFileName = Path.GetFileName(updateBrandModel.file.FileName);
                string physicalFileName = _fileUploadHelper.GetUniqueFileName(originalFileName);
                string physicalFolderPath = _fileUploadHelper.GetUsersFolderPath(true);
                string physicalFileFullPath = Path.Combine(physicalFolderPath, physicalFileName);
                if (!Directory.Exists(physicalFolderPath))
                {
                    Directory.CreateDirectory(physicalFolderPath);
                }
                using var stream = System.IO.File.Create(physicalFileFullPath);
                // Upload File
                await updateBrandModel.file.CopyToAsync(stream);
                updateBrandModel.BrandImagePath = physicalFileFullPath;
                bool resultUpdateID = await _brandManager.BrandMasterUpdateDetails(updateBrandModel);
                if (resultUpdateID == true)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.Found,
                        Message = Message.CommonUpdateMessage,
                        Data = resultUpdateID
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.OK,
                        Message = Message.BrandTypeNotExist,
                        Data = resultUpdateID
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
        [Authorize(Roles = StaticRoles.ADMIN)]
        [HttpGet("GetBrandMstDetails")]
        public async Task<ResultModel> GetBrandMstDetails()
        {
            try
            {
                var response = await _brandManager.GetBrandMstDetails();
                return new ResultModel()
                {
                    Code = HttpStatusCode.OK,
                    Message = Message.CommonGetMessage,
                    Data = response
                };
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
        [HttpDelete("BrandMasterDeleteDetails")]
        public async Task<ResultModel> BrandMasterDeleteDetails([FromBody] DeleteBrandModel deleteBrandModel)
        {
            try
            {
                bool DeleteStatus = await _brandManager.BrandMasterDeleteDetails(deleteBrandModel);
                if (DeleteStatus == true)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.OK,
                        Message = Message.CommonDeleteMessage,
                        Data = DeleteStatus
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.NotFound,
                        Message = Message.BrandTypeNotExist,
                        Data = DeleteStatus
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

