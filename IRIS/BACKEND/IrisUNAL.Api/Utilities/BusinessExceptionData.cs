using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Utilities
{
    public class BusinessExceptionData
    {
        public int Code { get; set; }
        public string Message { get; set; }
        public string ResultValue { get; set; }

    }
}