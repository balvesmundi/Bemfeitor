using System;
using Repository.Entities;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {

        void CreatePerson(Person person);

        Person GetPersonByKey(Guid personKey);
    }
}
