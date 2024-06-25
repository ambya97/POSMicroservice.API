using POS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business
{
    public interface IUnitManager
    {
        Task<int> UnitMasterInsertDetails(UnitModel unitModel);
    }
}
