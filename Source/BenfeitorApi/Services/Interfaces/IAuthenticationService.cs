using System;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface IAuthenticationService : IDisposable
    {
        AuthenticateResponse Authenticate(AuthenticateRequest request);
    }
}
