using System;
using BenfeitorApi.Models;
using BenfeitorApi.Models.Response;
using BenfeitorApi.Models.Request;

namespace BenfeitorApi.Services
{
    public interface IPersonService
    {
        PersonResponse CreatePerson(CreatePersonRequest request);
        PersonResponse GetPerson(Guid personKey);
        long GetPersonId(Guid personKey);
    }
}