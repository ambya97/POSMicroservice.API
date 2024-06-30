using POS.Core.Models.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Service
{
    public interface IBrandService
    {
        Task<int> BrandMasterInsertDetails(BrandInsertModel brandInsertModel);
        Task<IReadOnlyList<GetBrandModel>> GetBrandMstDetails();
    }
}
