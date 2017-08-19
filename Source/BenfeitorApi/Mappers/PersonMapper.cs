using System;
using System.Collections.Generic;
using System.Linq;
using BenfeitorApi.Models.Enums;
using BenfeitorApi.Models.Request;
using Domain.Aggregates.Entities;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;

namespace MundiPagg.Benfeitor.BenfeitorApi.Mappers
{
    public static class PersonMapper
    {

        public static Person MapPerson(CreatePersonRequest request)
        {

            return new Person()
            {
                BirthDate = request.BirthDate,
                CreateDate = DateTime.UtcNow,
                Email = request.Email,
                FacebookId = request.FacebookId,
                GenderEnum = request.GenderEnum,
                HomePhone = request.HomePhone,
                MobilePhone = request.MobilePhone,
                Name = request.Name,
                PersonKey = Guid.NewGuid(),
                TwitterId = request.TwitterId,
                WorkPhone = request.WorkPhone,
                Addresses = new List<Address>(){
                    PersonMapper.MapAddress(request.Address)
                },
                BalanceInCents = request.BalanceInCents,
                DueDate = request.DueDate,
                LoanInCents = request.LoanInCents,
                LoanTypeEnum = request.LoanTypeEnum.ToString(),
                TaxPerDay = request.TaxPerDay,
                Documents = PersonMapper.MapDocuments(request.Documents),
                IsEnabled = true,
                Username = request.Username,
                Password = request.Password
            };
        }

        public static Person UpdatePerson(CreatePersonRequest request)
        {

            return new Person()
            {
                BirthDate = request.BirthDate,
                CreateDate = DateTime.UtcNow,
                Email = request.Email,
                FacebookId = request.FacebookId,
                GenderEnum = request.GenderEnum,
                HomePhone = request.HomePhone,
                MobilePhone = request.MobilePhone,
                Name = request.Name,
                PersonKey = Guid.NewGuid(),
                TwitterId = request.TwitterId,
                WorkPhone = request.WorkPhone,
                Addresses = new List<Address>(){
                    PersonMapper.MapAddress(request.Address)
                },
                BalanceInCents = request.BalanceInCents,
                DueDate = request.DueDate,
                LoanInCents = request.LoanInCents,
                LoanTypeEnum = request.LoanTypeEnum.ToString(),
                TaxPerDay = request.TaxPerDay,
                Documents = PersonMapper.MapDocuments(request.Documents)
            };
        }

        private static List<Document> MapDocuments(List<CreateDocumentRequest> documentsRequest)
        {
            if (documentsRequest == null)
                return null;

            var documentsList = new List<Document>();

            foreach (var docRequest in documentsRequest)
            {
                documentsList.Add(new Document()
                {
                    DocumentNumber = docRequest.DocumentNumber,
                    DocumentType = docRequest.DocumentType
                });
            }

            return documentsList;
        }

        private static Address MapAddress(CreateAddressRequest addressRequest)
        {
            if (addressRequest == null) { return null; }

            return new Address()
            {
                City = addressRequest.City,
                Complement = addressRequest.Complement,
                Country = addressRequest.Country,
                District = addressRequest.District,
                Number = addressRequest.Number,
                State = addressRequest.State,
                Street = addressRequest.Street,
                ZipCode = addressRequest.ZipCode
            };
        }

        public static PersonResponse MapPersonResponse(Person person)
        {
            LoanTypeEnum loanTypeEnum = LoanTypeEnum.Undefined;
            Enum.TryParse<LoanTypeEnum>(person.LoanTypeEnum, out loanTypeEnum);

            return new PersonResponse()
            {
                PersonKey = person.PersonKey,
                CreateDate = person.CreateDate,
                Email = person.Email,
                Name = person.Name,
                FacebookId = person.FacebookId,
                TwitterId = person.TwitterId,
                GenderEnum = person.GenderEnum,
                MobilePhone = person.MobilePhone,
                HomePhone = person.HomePhone,
                WorkPhone = person.WorkPhone,
                BirthDate = person.BirthDate,
                BalanceInCents = person.BalanceInCents,
                LoanTypeEnum = loanTypeEnum,
                LoanInCents = person.LoanInCents,
                DueDate = person.DueDate,
                TaxPerDay = person.TaxPerDay,
                Address = PersonMapper.MapAddressResponse(person.Addresses?.FirstOrDefault()),
                Documents = MapDocumentsResponse(person.Documents)
            };
        }

        public static AddressResponse MapAddressResponse(Address address)
        {
            if (address == null) return null;

            return new AddressResponse()
            {
                City = address.City,
                Complement = address.Complement,
                Country = address.Country,
                District = address.District,
                Number = address.Number,
                State = address.State,
                ZipCode = address.ZipCode,
                Street = address.Street
            };
        }

        public static List<DocumentResponse> MapDocumentsResponse(List<Document> documents)
        {
            if (documents == null) return null;

            var docs = new List<DocumentResponse>();

            foreach (var doc in documents)
            {
                docs.Add(new DocumentResponse()
                {
                    DocumentNumber = doc.DocumentNumber,
                    DocumentType = doc.DocumentType
                });
            }

            return docs;
        }
    }
}