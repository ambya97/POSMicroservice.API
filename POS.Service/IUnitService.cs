using POS.Core.Models;
using POS.Core.Models.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public interface IUnitService
    {
        Task<int> UnitMasterInsertDetails(UnitModel unitModel);
        Task<IReadOnlyList<GetUnitModel>> GetUnitMstDetails();
        Task<bool> UnitMasterUpdateDetails(UpdateUnitModel updateUnitModel);
    }
}
