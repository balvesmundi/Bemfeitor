//using System;
//using System.Transactions;
//using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
//using MundiPagg.Benfeitor.BenfeitorApi.Models;
//using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
//using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
//using MundiPagg.Benfeitor.BenfeitorApi.Seedwork.Exceptions;
//using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
//using System.Collections.Generic;
//using MundiPagg.Benfeitor.Domain.Seedwork.Specifications;
//using Domain.Aggregates.Entities;
//using System.Linq;
//using BenfeitorApi.Models.Enums;
//using MundiPagg.Benfeitor.BenfeitorApi.Models.Enums;

//namespace MundiPagg.Benfeitor.BenfeitorApi.Services
//{
//    public class RecipientService : IRecipientService
//    {

//        private IPersonRepository _personRepository;

//        public RecipientService(IPersonRepository personRepository, IAddressRepository addressRepository, ILoanRepository loanRepository)
//        {

//            this._personRepository = personRepository;
//            this._addressRepository = addressRepository;
//            this._loanRepository = loanRepository;
//        }

//        public RecipientResponse CreateRecipient(CreatePersonRequest request)
//        {
//            if (string.IsNullOrWhiteSpace(request.Username))
//            {
//                throw new BadRequestException("Invalid username.");
//            }

//            var person = this._personRepository.FindOne(p => p.Username == request.Username);
//            if (person != null)
//            {
//                throw new BadRequestException("The specified user already exists.");
//            }

//            person = PersonMapper.MapPerson(request);

//            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
//            {
//                this._personRepository.Add(person);

//                this._personRepository.UnitOfWork.Commit();


//                scope.Complete();
//            }

//            return PersonMapper.MapPersonResponse(person);

//        }

//        public RecipintResponse GetRecipient(Guid personKey)
//        {
//            var person = this._personRepository.FindOne(p => p.PersonKey == personKey,
//                include => include.Addresses,
//                include => include.Documents);

//            return PersonMapper.MapPersonResponse(person);
//        }

//        #region IDisposable Members

//        public void Dispose()
//        {
//            this._personRepository.Dispose();
//            this._addressRepository.Dispose();
//        }

//        #endregion
//    }
//}