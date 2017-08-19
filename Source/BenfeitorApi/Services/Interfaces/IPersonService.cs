using System;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface IPersonService : IDisposable
    {
        PersonResponse CreatePerson(CreatePersonRequest request);
        PersonResponse GetPerson(Guid personKey);
        long GetPersonId(Guid personKey);
        PersonResponse PatchPerson(CreatePersonRequest request);
        void DeletePerson(Guid personKey);
    }
}