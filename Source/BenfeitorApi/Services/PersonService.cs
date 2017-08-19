using System;
using BenfeitorApi.Mappers;
using BenfeitorApi.Models;
using Repository.Interfaces;
using BenfeitorApi.Models.Response;
using BenfeitorApi.Models.Request;

namespace BenfeitorApi.Services
{
    public class PersonService : IPersonService
    {

        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {

            this._personRepository = personRepository;
        }

        public PersonResponse CreatePerson(CreatePersonRequest request)
        {
            var person = PersonMapper.MapPerson(request);

            this._personRepository.CreatePerson(person);

            return PersonMapper.MapPersonResponse(person);
        }

        public PersonResponse GetPerson(Guid personKey)
        {
            var person = this._personRepository.GetPerson(personKey);

            return PersonMapper.MapPersonResponse(person);
        }
    }
}