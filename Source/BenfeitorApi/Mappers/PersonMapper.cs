using System;
using BenfeitorApi.Models;
using Repository.Entities;
using BenfeitorApi.Models.Request;
using BenfeitorApi.Models.Response;
using System.Collections.Generic;

namespace BenfeitorApi.Mappers
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
                Address = PersonMapper.MapAddress(request.Address),
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
            throw new NotImplementedException();
        }

        public static AddressResponse MapAddressResponse(Address address)
        {
            throw new NotImplementedException();
        }
    }
}