using Api.Core.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.Core.Response
{
    public class ApiResponseSuccess<T>
    {
        public ApiResponseSuccess(T success)
        {
            Success = success;
        }
        public T Success { get; set; }
        public Metadata Pagination { get; set; }


        //PATRON DE DISEÑO SINGLETON
        //static private ApiResponseSuccess<T> responseSuccess = new ApiResponseSuccess<T>();

        //public ApiResponseSuccess(){}

        //static public ApiResponseSuccess<T> getResponseSucces()
        //{
        //    return responseSuccess;
        //}
    }

    public class ApiResponseErrors<T>
    {
        public ApiResponseErrors(T errors)
        {
            Errors = errors;
        }
        public T Errors { get; set; }

    }
}
