using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace repositoryMongoExample.Responses
{
    public class BaseResponse
    {
        public string Code { get; set; }
        public dynamic Content { get; set; }
        public string Message { get; set; }


        public BaseResponse Succeed(string message,dynamic content)
        {
            Content = content;
            Message = message;
            Code = "0000";
            return this;

        }

        

        public BaseResponse Failed(string code, string message)
        {
            Code = code;
            Message = message;
            Content = null;
            return this;
        }
        public BaseResponse Exeption(Exception ex)
        {
            Code = "0006";
            Message = ex.Message;
            Content = null;
            return this;
        }

    }
}
