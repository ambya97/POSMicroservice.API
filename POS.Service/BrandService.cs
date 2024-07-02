using POS.Core.Models.Brands;
using POS.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;
        public BrandService(IBrandRepository brandRepository) 
        { 
            _brandRepository = brandRepository;
        }

        public async Task<bool> BrandMasterDeleteDetails(DeleteBrandModel deleteBrandModel)
        {
            return await _brandRepository.BrandMasterDeleteDetails(deleteBrandModel);
        }

        public async Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel)
        {
            return await _brandRepository.BrandMasterInsertDetails(brandInsertModel);
        }

        public async Task<bool> BrandMasterUpdateDetails(UpdateBrandModel updateBrandModel)
        {
            return await _brandRepository.BrandMasterUpdateDetails(updateBrandModel);
        }

        public async Task<IReadOnlyList<GetBrandModel>> GetBrandMstDetails()
        {
          return  await _brandRepository.GetBrandMstDetails();
        }
    }
}
