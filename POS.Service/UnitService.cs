﻿using POS.Core.Models;
using POS.Core.Models.Unit;
using POS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class UnitService : IUnitService
    {
        private readonly IUnitRepository _unitRepository;
        public UnitService(IUnitRepository unitRepository) {
            _unitRepository = unitRepository;

        }

        public async Task<IReadOnlyList<GetUnitModel>> GetUnitMstDetails()
        {
            return await _unitRepository.GetUnitMstDetails();
        }

        public async Task<bool> UnitMasterDeleteDetails(UpdateUnitModel updateUnitModel)
        {
            return await _unitRepository.UnitMasterDeleteDetails(updateUnitModel);
        }

        public async Task<int> UnitMasterInsertDetails(UnitModel unitModel)
        {
          return await _unitRepository.UnitMasterInsertDetails(unitModel);
        }

        public async Task<bool> UnitMasterUpdateDetails(UpdateUnitModel updateUnitModel)
        {
            return await _unitRepository.UnitMasterUpdateDetails(updateUnitModel);
        }
    }
}
