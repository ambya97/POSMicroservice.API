using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Brands
{
    public class UpdateBrandModel
    {
        public int BrandId { get; set; }
        public string BrandName { get; set; } = string.Empty;
    }
}
