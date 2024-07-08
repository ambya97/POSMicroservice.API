using POS.Core.Models.Register;
using POS.Core.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business
{
    public interface IRegisterManager
    {
        Task<int> InsertRegisterDetails(RegisterModel registerModel);
        Task<AuthServiceResponseDto> RegisterAsync(RegisterModel registerModel);
    }
}
