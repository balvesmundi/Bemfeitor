using System;
using System.Transactions;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using System.Collections.Generic;
using MundiPagg.Benfeitor.Domain.Seedwork.Specifications;
using Domain.Aggregates.Entities;
using System.Linq;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public class PersonService : IPersonService
    {

        private IPersonRepository _personRepository;
        private IAddressRepository _addressRepository;
        private ILoanRepository _loanRepository;

        public PersonService(IPersonRepository personRepository, IAddressRepository addressRepository, ILoanRepository loanRepository)
        {

            this._personRepository = personRepository;
            this._addressRepository = addressRepository;
            this._loanRepository = loanRepository;
        }

        public PersonResponse CreatePerson(CreatePersonRequest request)
        {
            try
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
            catch (Exception ex)
            {
                throw;
            }
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
            var person = this._personRepository.FindOne(p => p.PersonKey == personKey);

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

        public List<PersonResponse> Search(Guid personKey, SearchRequest request)
        {
            #region Filters

            Specification<Person> filter = new DirectSpecification<Person>(p => p.IsEnabled == true);

            if (string.IsNullOrWhiteSpace(request.Name) == false) filter &= new DirectSpecification<Person>(p => p.Name == request.Name);
            if (request.MininumGrade.HasValue)
            {
                filter &= new DirectSpecification<Person>(p => (double)p.SumGrade / p.CountGrade > request.MininumGrade);
            }
            if (request.AmountInCents.HasValue)
            {
                if (request.TypeSearch == Models.Enums.TypeSearch.FindingBorrowers) // valor máximo
                    filter &= new DirectSpecification<Person>(p => p.LoanInCents <= request.AmountInCents);
                else // valor mínimo
                    filter &= new DirectSpecification<Person>(p => p.LoanInCents >= request.AmountInCents);
            }
            if (request.HasBorrowed.HasValue && request.HasBorrowed == true)
            {
                filter &= new DirectSpecification<Person>(p => p.HasBorrowed == true);
            }
            if (request.HasLended.HasValue && request.HasLended == true)
            {
                filter &= new DirectSpecification<Person>(p => p.HasLended == true);
            }

            #endregion

            var people = _personRepository.FindAll(filter).ToList();

            return PersonMapper.MapPersonResponse(people);
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