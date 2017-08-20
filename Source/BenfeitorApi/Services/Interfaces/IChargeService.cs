using System;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface IChargeService : IDisposable
    {
        ChargeResponse CreateCharge(CreateChargeRequest request);
    }
}