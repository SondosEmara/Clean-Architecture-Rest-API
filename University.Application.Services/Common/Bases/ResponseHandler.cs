using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Application.Layer.Common.Bases
{
    public static class  ResponseHandler
    {

        public static Response<T>Success<T>(T data) => new Response<T>(data);

        public static Response<T> Failed<T>(T data) => new Response<T>(data);
        public static Response<T> Failed<T>() => new Response<T>();

        public static Response<T> FaildException<T>(Exception ex) => new Response<T>(ex);

    }
}
