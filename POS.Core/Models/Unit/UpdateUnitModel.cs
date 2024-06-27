using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Unit
{
    public class UpdateUnitModel
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; } = string.Empty;
    }
}
