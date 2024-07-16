using Dapper;
using POS.Core.Models;
using POS.Core.Models.Unit;
using POS.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repository
{
    public class UnitRepository : IUnitRepository
    {
        private readonly IDbConnection _dbConnection;
        public UnitRepository(IDbConnection dbConnection) {
        _dbConnection = dbConnection;
        }

        public async Task<IReadOnlyList<GetUnitModel>> GetUnitMstDetails()
        {
            var dp = new DynamicParameters();
          var result= await  _dbConnection.QueryAsync<GetUnitModel>(
                sql: StoredProcedure.GetUnitMstDetails,
                    param: dp,
                    commandType: CommandType.StoredProcedure
                );
            return result.ToList();
        }

        public async Task<bool> UnitMasterDeleteDetails(UpdateUnitModel updateUnitModel)
        {
            var dp = new DynamicParameters();
            dp.Add("@UnitId", updateUnitModel.UnitId);
            dp.Add("@UnitName", updateUnitModel.UnitName);
            return await _dbConnection.QueryFirstOrDefaultAsync<bool>(
                   sql: StoredProcedure.UnitMstDeleteDetails,
                   param: dp,
                   commandType: CommandType.StoredProcedure);
      
        }

        public async Task<int> UnitMasterInsertDetails(UnitModel unitModel)
        {
            var dp = new DynamicParameters();
            dp.Add("@UnitName", unitModel.UnitName);
            dp.Add("@Createdby", unitModel.Createdby);
            var userInfoModel = await _dbConnection.QueryFirstOrDefaultAsync<int>(
                    sql: StoredProcedure.UnitMasterInsertDetails,
                    param: dp,
                    commandType: CommandType.StoredProcedure);
            return userInfoModel;
        }

        public async Task<bool> UnitMasterUpdateDetails(UpdateUnitModel updateUnitModel)
        {
            var dp = new DynamicParameters();
            dp.Add("@UnitId", updateUnitModel.UnitId);
            dp.Add("@UnitName", updateUnitModel.UnitName);
            var updateInfoModel = await _dbConnection.QueryFirstOrDefaultAsync<bool>(
                   sql: StoredProcedure.UnitUpdateDetails,
                   param: dp,
                   commandType: CommandType.StoredProcedure);
            return updateInfoModel;
        }
    }
}
