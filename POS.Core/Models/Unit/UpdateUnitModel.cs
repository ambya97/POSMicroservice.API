using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Unit
{
    public class UpdateUnitModel
    {
        [Required]
        public int UnitId { get; set; }
        [Required]
        public string UnitName { get; set; } = string.Empty;
        
        public int Updatedby { get; set; }
    }
}
