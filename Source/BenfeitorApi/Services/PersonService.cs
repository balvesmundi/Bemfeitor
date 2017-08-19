using System;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.Repository.Interfaces;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
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
            var person = this._personRepository.GetPersonByKey(personKey);

            return PersonMapper.MapPersonResponse(person);
        }
    }
}