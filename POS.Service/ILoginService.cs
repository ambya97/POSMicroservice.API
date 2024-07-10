using POS.Core.Models.Register;
using POS.Core.Models.Roleclaims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public interface ILoginService
    {
        Task<GetRegisterModel> FindByEmailDetails(string Email);
        Task<GetRoleModel> GetRolesAsync(int UserID);
    }
}
