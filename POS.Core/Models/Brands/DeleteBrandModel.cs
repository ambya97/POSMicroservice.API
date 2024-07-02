using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Brands
{
    public class DeleteBrandModel
    {
        [Required]
        public int BrandId { get; set; }
        [Required]
        public string BrandName { get; set; } = string.Empty;
    }
}
