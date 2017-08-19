using System;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.Repository.Entities;

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
                Address = PersonMapper.MapAddress(request.Address)
            };
        }

        public static Address MapAddress(CreateAddressRequest request)
        {
            if (request == null) { return null; }

            return new Address()
            {
                City = request.City,
                Complement = request.Complement,
                Country = request.Country,
                District = request.District,
                Number = request.Number,
                State = request.State,
                Street = request.Street,
                ZipCode = request.ZipCode
            };
        }

        public static PersonResponse MapPersonResponse(Person person)
        {
            return new PersonResponse()
            {
                Address = PersonMapper.MapAddressResponse(person.Address),
                BirthDate = person.BirthDate,
                CreateDate = person.CreateDate,
                Email = person.Email,
                FacebookId = person.FacebookId,
                GenderEnum = person.GenderEnum,
                HomePhone = person.HomePhone,
                MobilePhone = person.MobilePhone,
                Name = person.Name,
                PersonKey = person.PersonKey,
                TwitterId = person.TwitterId,
                WorkPhone = person.WorkPhone
            };
        }

        public static AddressResponse MapAddressResponse(Address address)
        {

            return new AddressResponse()
            {
                City = address.City,
                Complement = address.Complement,
                Country = address.Country,
                District = address.District,
                Number = address.Number,
                State = address.State,
                Street = address.Street,
                ZipCode = address.ZipCode
            };
        }
    }
}