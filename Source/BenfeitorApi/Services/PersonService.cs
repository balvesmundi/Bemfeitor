using System;
using System.Transactions;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using MundiPagg.Benfeitor.BenfeitorApi.Seedwork.Exceptions;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using System.Collections.Generic;
using MundiPagg.Benfeitor.Domain.Seedwork.Specifications;
using Domain.Aggregates.Entities;
using System.Linq;
using BenfeitorApi.Models.Enums;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Enums;

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
            if (request == null) return null;

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var person = this._personRepository.FindOne(p => p.PersonKey == personKey);

                if (request.BirthDate != null) person.BirthDate = request.BirthDate;
                if (request.Email != null) person.Email = request.Email;
                if (request.FacebookId != null) person.FacebookId = request.FacebookId;
                if (request.GenderEnum != null) person.GenderEnum = request.GenderEnum;
                if (request.HomePhone != null) person.HomePhone = request.HomePhone;
                if (request.MobilePhone != null) person.MobilePhone = request.MobilePhone;
                if (request.Name != null) person.Name = request.Name;
                if (request.TwitterId != null) person.TwitterId = request.TwitterId;
                if (request.WorkPhone != null) person.WorkPhone = request.WorkPhone;
                if (request.Address != null) person.Addresses = new List<Address>(){
                    PersonMapper.MapAddress(request.Address)
                };
                if (request.BalanceInCents != null) person.BalanceInCents = request.BalanceInCents;
                if (request.DueDate != null) person.DueDate = request.DueDate;
                if (request.LoanInCents != null) person.LoanInCents = request.LoanInCents;
                if (request.LoanTypeEnum != LoanTypeEnum.Undefined) person.LoanTypeEnum = request.LoanTypeEnum.ToString();
                if (request.TaxPerDay != null) person.TaxPerDay = request.TaxPerDay;
                if (request.Documents != null) person.Documents = PersonMapper.MapDocuments(request.Documents);
                if (request.Username != null) person.Username = request.Username;
                if (request.Password != null) person.Password = request.Password;

                this._personRepository.UnitOfWork.Commit();

                scope.Complete();

                return PersonMapper.MapPersonResponse(person);
            }
        }

        public PersonResponse GetPerson(Guid personKey)
        {
            var person = this._personRepository.FindOne(p => p.PersonKey == personKey,
                include => include.Addresses,
                include => include.Documents);

            return PersonMapper.MapPersonResponse(person);
        }

        public PersonResponse GetOtherPerson(Guid otherPersonKey)
        {
            var person = this._personRepository.FindOne(p => p.PersonKey == otherPersonKey);

            return PersonMapper.MapOtherPersonResponse(person);
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

        public List<PersonResponse> Search(SearchRequest request)
        {
            #region Filters

            Specification<Person> filter = new DirectSpecification<Person>(p => p.IsEnabled == true);

            if (string.IsNullOrWhiteSpace(request.Name) == false) filter &= new DirectSpecification<Person>(p => p.Name == request.Name);
            if (request.MininumGrade.HasValue)
            {
                filter &= new DirectSpecification<Person>(p => p.CountGrade > 0 ? (double)p.SumGrade / p.CountGrade >= request.MininumGrade : 0 >= request.MininumGrade);
            }
            if (request.AmountInCents.HasValue)
            {
                if (request.TypeSearch == TypeSearch.Lender) // valor máximo
                    filter &= new DirectSpecification<Person>(p => p.LoanInCents <= request.AmountInCents);
                else // valor mínimo
                    filter &= new DirectSpecification<Person>(p => p.LoanInCents >= request.AmountInCents);
            }
            if (request.HasBorrowed.HasValue && request.HasBorrowed == true)
            {
                filter &= new DirectSpecification<Person>(p => p.CountAsBorrower > 0);
            }
            if (request.HasLended.HasValue && request.HasLended == true)
            {
                filter &= new DirectSpecification<Person>(p => p.CountAsLender > 0);
            }

            #endregion

            var people = _personRepository.FindAll(filter).ToList();

            // Ordernação
            switch (request.TypeOrder)
            {
                case TypeOrder.AmountInCents:
                    people = people.OrderBy(p => p.LoanInCents).ToList();
                    break;
                case TypeOrder.Name:
                    people = people.OrderBy(p => p.Name).ToList();
                    break;
                case TypeOrder.Grade:
                default:
                    people = people.OrderByDescending(p => p.CountGrade > 0 ? (decimal)p.SumGrade / p.CountGrade : 0).ToList();
                    break;
            }

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