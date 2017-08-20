using System;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface IRecipientService : IDisposable
    {
        RecipientResponse CreateRecipient(CreateRecipientRequest request);
    }
}