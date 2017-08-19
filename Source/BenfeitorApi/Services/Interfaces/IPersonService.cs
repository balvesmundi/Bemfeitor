using System;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using System.Collections.Generic;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface IPersonService : IDisposable
    {
        PersonResponse CreatePerson(CreatePersonRequest request);
        PersonResponse GetPerson(Guid personKey);
        long GetPersonId(Guid personKey);
        PersonResponse UpdatePerson(Guid personKey, CreatePersonRequest request);
        void DeletePerson(Guid personKey);
        List<PersonResponse> Search(Guid personKey, SearchRequest request);
    }
}