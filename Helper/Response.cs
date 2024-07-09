using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppoinmentServices.Enum;

namespace AppoinmentServices.Helper
{
    public class Response<T>
    {
        public APIResponseStatus? status;
        public T? result;
        public string? message;
    }

}
