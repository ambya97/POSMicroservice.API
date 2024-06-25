using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace POS.Core.Models.Result
{
    public class ResultModel
    {
        public HttpStatusCode Code { get; set; }

        public string Message { get; set; }

        public object Data { get; set; }
    }
}
