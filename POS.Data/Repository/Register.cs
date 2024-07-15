using Dapper;
using POS.Core.Common;
using POS.Core.Enum;
using POS.Core.Models.Brands;
using POS.Core.Models.Register;
using POS.Core.Models.Result;
using POS.Data.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
namespace POS.Data.Repository
{
    public class Register : IRegister
    {
        private readonly IDbConnection _dbConnection;
       
        public Register(IDbConnection dbConnection)
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

        public async Task<int> InsertRegisterDetails(RegisterModel registerModel)
        {
          string passwordHash=  BCrypt.Net.BCrypt.HashPassword(registerModel.Password);
          bool verify=  BCrypt.Net.BCrypt.Verify(registerModel.Password, passwordHash);
            var dp = new DynamicParameters();
            dp.Add("@FirstName", registerModel.FirstName);
            dp.Add("@LastName", registerModel.LastName);
            dp.Add("@UserName", registerModel.UserName);
            dp.Add("@Email", registerModel.Email);
            dp.Add("@PasswordHash", passwordHash);
            int ResponseStatus = await _dbConnection.QueryFirstOrDefaultAsync<int>(
                    sql: StoredProcedure.InsertRegisterDts,
                    param: dp,
                    commandType: CommandType.StoredProcedure);
            return ResponseStatus;
        }

        public async Task<AuthServiceResponseDto> RegisterAsync(RegisterModel registerModel)
        {
           var isExistsUser= await FindByEmailDetails(registerModel.Email);
               if (isExistsUser != null)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "UserName Already Exists"
                };
           int createUserResult=await InsertRegisterDetails(registerModel);
            if (createUserResult == 0)
            {
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "User Creation Failed"
                };
            }
            await AddToRoleAsync(createUserResult, Convert.ToInt32(StaticUserRoles.UserRoles.ADMIN));
            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "User Created Successfully"
            };


        }
        public async Task AddToRoleAsync(int UserID, int RoleID)
        {
            var dp = new DynamicParameters();
            dp.Add("@UserId", UserID);
            dp.Add("@RoleId", RoleID);
             await _dbConnection.QueryAsync(
                    sql: StoredProcedure.InsertUpdateAddUserRoleDts,
                    param: dp,
                    commandType: CommandType.StoredProcedure);
           
        }
    }
}
