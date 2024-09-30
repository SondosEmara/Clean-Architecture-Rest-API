using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace University.Presentaion.Contracts.Bases
{
    public struct Response<T>
    {
        public bool IsSuccess { get; set; }
        public T? Result { get; set; }
        public string ErrorMessage { get; set; }

        public Response()
        {
            IsSuccess = false;
            ErrorMessage = string.Empty;
        }

        public Response(T result)
        {
            IsSuccess = true;
            Result = result;
            ErrorMessage = string.Empty;
        }

        public Response(Exception ex)
        {
            IsSuccess = false;
            Result = default(T);
            ErrorMessage = ex.Message;
        }
    }
}
