using POS.Core.Models.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business
{
    public interface IBrandManager
    {
        Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel);
        Task<IReadOnlyList<GetBrandModel>> GetBrandMstDetails();
        Task<bool> BrandMasterUpdateDetails(UpdateBrandModel updateBrandModel);
        Task<bool> BrandMasterDeleteDetails(DeleteBrandModel deleteBrandModel);
    }
}
