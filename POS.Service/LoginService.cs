using POS.Core.Models.Register;
using POS.Core.Models.Roleclaims;
using POS.Core.Models.User;
using POS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        public LoginService(ILoginRepository loginRepository) {
        _loginRepository = loginRepository;
        }

        public async Task<GetRegisterModel> FindByEmailDetails(string Email)
        {
            return await _loginRepository.FindByEmailDetails(Email);
        }

        public async Task<GetRoleModel> GetRolesAsync(int UserID)
        {
            return await _loginRepository.GetRolesAsync(UserID);
        }

        public async Task<UserModel> GetUserById(int userId)
        {
            return await _loginRepository.GetUserById(userId);
        }
    }
}
