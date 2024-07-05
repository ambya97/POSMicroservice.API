using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Roleclaims
{
    public class RoleclaimsModel
    {
        public int RoleClaimId { get; set; }
        public int RoleId { get; set; }
        public string  ClaimType { get; set; }=string.Empty;
        public string ClaimValue { get; set; } = string.Empty;
    }
}
