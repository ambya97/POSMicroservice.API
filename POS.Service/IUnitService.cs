using POS.Core.Models;
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
    }
}
