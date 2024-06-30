using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Brands
{
    public class GetBrandModel
    {
        public int BrandId { get; set; }
        public int IncrementNo { get; set; }
        public string BrandName { get; set; } = string.Empty;
        public string BrandImagePath { get; set; } = string.Empty;
    }
}
