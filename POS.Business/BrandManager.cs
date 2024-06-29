using POS.Core.Models.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business
{
    public class BrandManager : IBrandManager
    {
        private readonly IBrandManager _brandManager;
        public BrandManager(IBrandManager brandManager) 
        { 
         _brandManager = brandManager;
        }
        public async Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel)
        {
            return await _brandManager.BrandMasterInsertDetails(brandInsertModel);
        }
    }
}
