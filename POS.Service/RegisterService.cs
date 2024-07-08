using POS.Core.Models.Register;
using POS.Core.Models.Result;
using POS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class RegisterService : IRegisterService
    {
        private readonly IRegister _registerRepository;
        public RegisterService(IRegister registerRepository) { 
        _registerRepository = registerRepository;
        }
        public async Task<int> InsertRegisterDetails(RegisterModel registerModel)
        {
            return await _registerRepository.InsertRegisterDetails(registerModel);
        }

        public async Task<AuthServiceResponseDto> RegisterAsync(RegisterModel registerModel)
        {
            return await _registerRepository.RegisterAsync(registerModel);
        }
    }
}
