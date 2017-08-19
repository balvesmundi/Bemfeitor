using System;
using MundiPagg.Benfeitor.BenfeitorApi.Models;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface IPersonService : IDisposable
    {
        PersonResponse CreatePerson(CreatePersonRequest request);
        PersonResponse GetPerson(Guid personKey);
    }
}