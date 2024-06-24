using POS.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repository
{
    public interface IUnitRepository
    {
        Task<int> UnitMasterInsertDetails(UnitModel unitModel);
    }
}
