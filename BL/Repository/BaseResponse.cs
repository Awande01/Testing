using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BL.Repository
{
    public class BaseResponse<T> where T : class
    {
        public T ResponseObject { get; set; }

        public string  ResponseMessage {get; set;}

        public ResponseType ResponseType { get; set; }
    }

    public enum ResponseType
    {
        Success = 1,
        Failed = -1
    }
}