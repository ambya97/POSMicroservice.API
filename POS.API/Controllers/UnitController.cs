using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Business;
using POS.Core.Common;
using POS.Core.Enum;
using POS.Core.Models;
using POS.Core.Models.Result;
using POS.Core.Models.Unit;
using System.Net;
using System.Security.Claims;
using static POS.Core.Common.StaticValues;

namespace POS.API.Controllers
{
    [Authorize(Roles = StaticRoles.ADMIN)]
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        #region Global Variable
        private readonly  IUnitManager _unitManager;
        #endregion
        public UnitController(IUnitManager unitManager)
        {
            _unitManager = unitManager;
        }
        
        [HttpPost("UnitMasterInsertDetails")]
        public async Task<ResultModel> UnitMasterInsertDetails([FromBody]  UnitModel unitModel)
        {
            try
            {
                int userId = (int)HttpContext.Items[Claims.UserId];
                unitModel.Createdby = userId;
                int responseid = await _unitManager.UnitMasterInsertDetails(unitModel);
                if (responseid == 0) {
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
        
        [HttpGet("GetUnitMstDetails")]
        public async Task<ResultModel> GetUnitMstDetails()
        {
            
            try
            {
                var response =await _unitManager.GetUnitMstDetails();
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
        [Authorize]
        [HttpPut("UnitMasterUpdateDetails")]
        public async Task<ResultModel> UnitMasterUpdateDetails([FromBody] UpdateUnitModel updateUnitModel)
        {
            try
            {
                int userId = (int)HttpContext.Items[Claims.UserId];
                updateUnitModel.Updatedby = userId;
                bool responseid = await _unitManager.UnitMasterUpdateDetails(updateUnitModel);
                if (responseid == true)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.OK,
                        Message = Message.CommonUpdateMessage,
                        Data = responseid
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.NotFound,
                        Message = Message.UnitTypeNotExist,
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

        [Authorize]
        [HttpDelete("UnitMasterDeleteDetails")]
        public async Task<ResultModel> UnitMasterDeleteDetails([FromBody] UpdateUnitModel updateUnitModel)
        {
            try
            {
                bool responseid = await _unitManager.UnitMasterDeleteDetails(updateUnitModel);
                if (responseid == true)
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.OK,
                        Message = Message.CommonDeleteMessage,
                        Data = responseid
                    };
                }
                else
                {
                    return new ResultModel()
                    {
                        Code = HttpStatusCode.NotFound,
                        Message = Message.UnitTypeNotExist,
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
