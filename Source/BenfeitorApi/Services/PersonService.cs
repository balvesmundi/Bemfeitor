using System;
using System.Transactions;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
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
            try
            {
                var person = PersonMapper.MapPerson(request);

                using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
                {
                    this._personRepository.Add(person);


                    //this._addressRepository.UnitOfWork.Commit();
                    this._personRepository.UnitOfWork.Commit();


                    scope.Complete();
                }

                return PersonMapper.MapPersonResponse(person);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public PersonResponse PatchPerson(CreatePersonRequest request)
        {
            var personRequest = PersonMapper.MapPerson(request);

            var person = this._personRepository.PatchPerson(personRequest);

            return PersonMapper.MapPersonResponse(person);
        }

        public PersonResponse GetPerson(Guid personKey)
        {
            var person = this._personRepository.FindOne(p => p.PersonKey == personKey);

            return PersonMapper.MapPersonResponse(person);
        }

        public long GetPersonId(Guid personKey)
        {
            return this._personRepository.FindOne(p => p.PersonKey == personKey).PersonId;
        }

        public void DeletePerson(Guid personKey)
        {
            this._personRepository.DeletePerson(personKey);
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