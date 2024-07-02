using POS.Core.Models;
using POS.Core.Models.Brands;
using POS.Core.Models.Unit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repository
{
    public interface IBrandRepository
    {
        Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel);
        Task<IReadOnlyList<GetBrandModel>> GetBrandMstDetails();
        Task<bool> BrandMasterUpdateDetails(UpdateBrandModel updateBrandModel);
        Task<bool> BrandMasterDeleteDetails(DeleteBrandModel deleteBrandModel);
    }
}
