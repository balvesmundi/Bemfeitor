using System;
using BenfeitorApi.Models;
using Repository.Entities;

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
            throw new NotImplementedException();
        }

        public static AddressResponse MapAddressResponse(Address address)
        {
            throw new NotImplementedException();
        }
    }
}