using Dapper;
using POS.Core.Models;
using POS.Core.Models.Brands;
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
    public class BrandRepository : IBrandRepository
    {
        private readonly IDbConnection _dbConnection;
        public BrandRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<bool> BrandMasterDeleteDetails(DeleteBrandModel deleteBrandModel)
        {
            var dp = new DynamicParameters();
            dp.Add("@BrandId", deleteBrandModel.BrandId);
            dp.Add("@BrandName", deleteBrandModel.BrandName);
            return await _dbConnection.QueryFirstOrDefaultAsync<bool>(
                   sql: StoredProcedure.BrandMstDeleteDetails,
                   param: dp,
                   commandType: CommandType.StoredProcedure);
        }

        public async Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel)
        {
            var dp = new DynamicParameters();
            dp.Add("@BrandName", brandInsertModel.BrandName);
            dp.Add("@BrandImagePath", brandInsertModel.BrandImagePath);
            var BrandId = await _dbConnection.QueryFirstOrDefaultAsync<int>(
                    sql: StoredProcedure.BrandMstInsertDetails,
                    param: dp,
                    commandType: CommandType.StoredProcedure);
            return BrandId;
        }

        public async Task<bool> BrandMasterUpdateDetails(UpdateBrandModel updateBrandModel)
        {
            var dp= new DynamicParameters();
            dp.Add("@BrandId", updateBrandModel.BrandId);
            dp.Add("@BrandName", updateBrandModel.BrandName);
            dp.Add("@BrandImagePath", updateBrandModel.BrandImagePath);
            return await _dbConnection.QueryFirstOrDefaultAsync<bool>(
                sql: StoredProcedure.BrandMstUpdateDetails,
                param: dp,
                commandType: CommandType.StoredProcedure
                );
        }

        public async Task<IReadOnlyList<GetBrandModel>> GetBrandMstDetails()
        {
            var dp = new DynamicParameters();
            var BrandList = await _dbConnection.QueryAsync<GetBrandModel>(
                  sql: StoredProcedure.GetBrandMstDetails,
                      param: dp,
                      commandType: CommandType.StoredProcedure
                  );
            return BrandList.ToList();
        }
    }
}
