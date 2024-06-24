using Dapper;
using POS.Core.Models;
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
        public async Task<int> UnitMasterInsertDetails(UnitModel unitModel)
        {
            var dp = new DynamicParameters();
            dp.Add("@UnitName", unitModel.UnitName);
            var userInfoModel = await _dbConnection.QueryFirstOrDefaultAsync<int>(
                    sql: "UnitMasterInsertDetails",
                    param: dp,
                    commandType: CommandType.StoredProcedure);

  
            return userInfoModel;
        }
    }
}
