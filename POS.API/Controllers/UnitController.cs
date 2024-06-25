using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Business;
using POS.Core.Common;
using POS.Core.Models;
using POS.Core.Models.Result;
using System.Net;

namespace POS.API.Controllers
{
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
        [HttpPost("")]
        public async Task<ResultModel> UnitMasterInsertDetails(UnitModel unitModel)
        {
            try
            {
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

    }
}
