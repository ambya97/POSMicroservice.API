﻿using POS.Core.Models.Login;
using POS.Core.Models.Register;
using POS.Core.Models.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repository
{
    public interface ILoginRepository
    {
        Task<GetRegisterModel> FindByEmailDetails(string Email);
        Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto);
    }
}
