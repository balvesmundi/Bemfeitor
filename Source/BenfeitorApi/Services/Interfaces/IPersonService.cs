using System;
using BenfeitorApi.Models;

namespace BenfeitorApi.Services
{
    public interface IPersonService
    {
        PersonResponse CreatePerson(CreatePersonRequest request);
        PersonResponse GetPerson(Guid personKey);
    }
}