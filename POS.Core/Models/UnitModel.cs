using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models
{
    public class UnitModel
    {
        // public int? UnitId { get; set; }
        [Required]
        public string UnitName { get; set; }=string.Empty;
    }
}
