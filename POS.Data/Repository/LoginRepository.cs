using Dapper;
using POS.Core.Common;
using POS.Core.Models.Login;
using POS.Core.Models.Register;
using POS.Core.Models.Result;
using POS.Core.Models.Roleclaims;
using POS.Core.Models.User;
using POS.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbConnection _dbConnection;

        public LoginRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        public async Task<GetRegisterModel> FindByEmailDetails(string Email)
        {
            var dp = new DynamicParameters();
            dp.Add("@Email", Email);
            var isExistsUsermodel = await _dbConnection.QueryFirstOrDefaultAsync<GetRegisterModel>(
                   sql: StoredProcedure.FindByEmailSP,
                   param: dp,
                   commandType: CommandType.StoredProcedure);
            return isExistsUsermodel;
        }

       
        public async Task<GetRoleModel> GetRolesAsync(int UserID)
        {
            var dp = new DynamicParameters();
            dp.Add("@UserId", UserID);
            var Roletype = await _dbConnection.QueryFirstOrDefaultAsync<GetRoleModel>(
                   sql: StoredProcedure.GetUserRoleDts,
                   param: dp,
                   commandType: CommandType.StoredProcedure);
            return Roletype ;
        }

        public async Task<UserModel> GetUserById(int userId)
        {
            var dp = new DynamicParameters();
            dp.Add("@UserId", userId);

            var Usermodel= await _dbConnection.QueryFirstOrDefaultAsync<UserModel>(
                    sql: StoredProcedure.GetUserByIdSP,
                    param: dp,
                    commandType: CommandType.StoredProcedure);
            return Usermodel;
        }
    }
}
