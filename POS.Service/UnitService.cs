using POS.Core.Models;
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
        public async Task<int> UnitMasterInsertDetails(UnitModel unitModel)
        {
          return await _unitRepository.UnitMasterInsertDetails(unitModel);
        }
    }
}
