using POS.Core.Models.Brands;
using POS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business
{
    public class BrandManager : IBrandManager
    {
        private readonly IBrandService _brandService;
        public BrandManager(IBrandService brandService) 
        {
            _brandService = brandService;
        }
        public async Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel)
        {

            return await _brandService.BrandMasterInsertDetails(brandInsertModel);
        }
    }
}
