using System;
using System.Transactions;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using MundiPagg.Benfeitor.BenfeitorApi.Seedwork.Exceptions;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public class PersonService : IPersonService
    {

        private IPersonRepository _personRepository;
        private IAddressRepository _addressRepository;

        public PersonService(IPersonRepository personRepository, IAddressRepository addressRepository)
        {

            this._personRepository = personRepository;
            this._addressRepository = addressRepository;
        }

        public PersonResponse CreatePerson(CreatePersonRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Username))
            {
                throw new BadRequestException("Invalid username.");
            }

            var person = this._personRepository.FindOne(p => p.Username == request.Username);
            if (person != null)
            {
                throw new BadRequestException("The specified user already exists.");
            }

            person = PersonMapper.MapPerson(request);

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                this._personRepository.Add(person);

                this._personRepository.UnitOfWork.Commit();


                scope.Complete();
            }

            return PersonMapper.MapPersonResponse(person);

        }

        public PersonResponse UpdatePerson(Guid personKey, CreatePersonRequest request)
        {
            //var personRequest = PersonMapper.MapPerson(request);

            //var person = this._personRepository.PatchPerson(personRequest);


            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var person = this._personRepository.FindOne(p => p.PersonKey == personKey);
                PersonMapper.MapPerson(request);

                this._personRepository.UnitOfWork.Commit();

                scope.Complete();

                return PersonMapper.MapPersonResponse(person);
            }
        }

        public PersonResponse GetPerson(Guid personKey)
        {
            var person = this._personRepository.FindOne(p => p.PersonKey == personKey, include => include.Addresses);

            return PersonMapper.MapPersonResponse(person);
        }

        public long GetPersonId(Guid personKey)
        {
            return this._personRepository.FindOne(p => p.PersonKey == personKey).PersonId;
        }

        public void DeletePerson(Guid personKey)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var person = this._personRepository.FindOne(p => p.PersonKey == personKey);
                person.IsEnabled = false;

                this._personRepository.UnitOfWork.Commit();

                scope.Complete();
            }
        }

        #region IDisposable Members

        public void Dispose()
        {
            this._personRepository.Dispose();
            this._addressRepository.Dispose();
        }

        #endregion
    }
}