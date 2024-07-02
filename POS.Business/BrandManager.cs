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

        public async Task<bool> BrandMasterDeleteDetails(DeleteBrandModel deleteBrandModel)
        {
            return await _brandService.BrandMasterDeleteDetails(deleteBrandModel);
        }

        public async Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel)
        {

            return await _brandService.BrandMasterInsertDetails(brandInsertModel);
        }

        public async Task<bool> BrandMasterUpdateDetails(UpdateBrandModel updateBrandModel)
        {
            return await _brandService.BrandMasterUpdateDetails(updateBrandModel);
        }

        public async Task<IReadOnlyList<GetBrandModel>> GetBrandMstDetails()
        {
            return await _brandService.GetBrandMstDetails();
        }
    }
}
