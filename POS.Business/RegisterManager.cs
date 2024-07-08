using POS.Core.Models.Register;
using POS.Core.Models.Result;
using POS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business
{
    public class RegisterManager : IRegisterManager
    {
        private readonly IRegisterService _registerService;
        public RegisterManager(IRegisterService registerService)
        {
          _registerService = registerService; 
        }
        public async Task<int> InsertRegisterDetails(RegisterModel registerModel)
        {
            return await _registerService.InsertRegisterDetails(registerModel); 
        }

        public async Task<AuthServiceResponseDto> RegisterAsync(RegisterModel registerModel)
        {
            return await _registerService.RegisterAsync(registerModel);
        }
    }
}
