using POS.Core.Models;
using POS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business
{
    public class UnitManager : IUnitManager
    {
        private readonly IUnitService _unitService;
        public UnitManager(IUnitService unitService) {
            _unitService = unitService; 
        }
        public async Task<int> UnitMasterInsertDetails(UnitModel unitModel)
        {
            return await _unitService.UnitMasterInsertDetails(unitModel);
        }
    }
}
