using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EventMgt.Core.Responses
{
    public class ResponseModel
    {
        public HttpStatusCode StatusCode { get; set; }
        public string Msg { get; set; }
        public object Data { get; set; }
    }
}
