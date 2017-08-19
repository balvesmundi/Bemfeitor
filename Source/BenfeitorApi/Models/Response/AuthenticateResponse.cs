using System;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Response
{
    public class AuthenticateResponse
    {

        public bool Success { get; set; }

        public string Bearer { get; set; }

        public Guid PersonKey { get; set; }
    }
}