using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IrisUNAL.Api.Utilities
{
    public class BusinessException : Exception
    {
        static readonly List<BusinessExceptionData> data = new List<BusinessExceptionData>() {
            new BusinessExceptionData() {Code=1,Message="" } };

        public BusinessException(int code, string resultValue = null, string message = null) : base(message)
        {
            Current = data.FirstOrDefault(o => o.Code == code);
            if (Current == null)
                Current = new BusinessExceptionData();
            if (!string.IsNullOrEmpty(message))
                Current.Message = message;
            if (string.IsNullOrEmpty(Current.Message))
                Current.Message = code.ToString();

            Current.ResultValue = resultValue;
        }

        public BusinessException(string resultValue = null, string message = null) : this(-1, resultValue, message)
        {

        }

        public BusinessException(string message) : this(null, message)
        {

        }

        public BusinessExceptionData Current { get; set; }
    }
}