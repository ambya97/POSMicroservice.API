using POS.Core.Models.Login;
using POS.Core.Models.Register;
using POS.Core.Models.Result;
using POS.Core.Models.Roleclaims;
using POS.Core.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business
{
    public interface ILoginManager
    {
        
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
        Task<UserModel> GetUserById(int userId);

    }
}
