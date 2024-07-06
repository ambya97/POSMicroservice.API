using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.UserToken
{
    public class UserTokenModel
    {
        public int UserTokenID { get; set; }
        public string TokenValue  { get; set; } =string.Empty;
        public int UserId { get; set; }
    }
}
