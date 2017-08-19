using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BenfeitorApi.Models;
using Repository.Interfaces;

namespace BenfeitorApi.Services
{
    public class PersonService : IPersonService
    {

        private IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {

            this._personRepository = personRepository;

        }

        public PersonResponse CreateAccount(CreatePersonRequest request)
        {
            // TODO: Create account

            var id = "1";

            return this.GetAccount(id);
        }

        public PersonResponse GetAccount(string id)
        {

            throw new NotImplementedException();
        }
    }
}