using System;
using Repository.Entities;
using Repository.Interfaces;

namespace Repository
{
    public class PersonRepository : IPersonRepository
    {
        public void CreatePerson(Person person)
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(Guid personKey)
        {
            throw new NotImplementedException();
        }

        public long GetPersonId(Guid personKey)
        {
            throw new NotImplementedException();
        }
    }
}
