using System;

namespace MundiPagg.Benfeitor.BenfeitorApi.Seedwork.Exceptions
{
    public class BadRequestException : Exception
    {

        public BadRequestException(string message) : base(message)
        {
        }
    }
}