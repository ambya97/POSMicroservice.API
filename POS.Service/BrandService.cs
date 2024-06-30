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
        public async Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel)
        {
            return await _brandRepository.BrandMasterInsertDetails(brandInsertModel);
        }

        public async Task<IReadOnlyList<GetBrandModel>> GetBrandMstDetails()
        {
          return  await _brandRepository.GetBrandMstDetails();
        }
    }
}
