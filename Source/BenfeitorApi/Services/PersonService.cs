using System;
using System.Transactions;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.Domain.Aggregates.CustomerAgg.Repositories;

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

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                this._personRepository.Add(person);

                this._personRepository.UnitOfWork.Commit();

                scope.Complete();
            }

            return PersonMapper.MapPersonResponse(person);
        }

        public PersonResponse GetPerson(Guid personKey)
        {
            var person = this._personRepository.FindOne(p => p.PersonKey == personKey);

            return PersonMapper.MapPersonResponse(person);
        }


        #region IDisposable Members

        public void Dispose()
        {
            this._personRepository.Dispose();
        }

        #endregion
    }
}