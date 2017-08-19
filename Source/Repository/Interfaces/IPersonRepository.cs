using System;
using Repository.Entities;

namespace Repository.Interfaces
{
    public interface IPersonRepository
    {

        void CreatePerson(Person person);

        Person GetPerson(Guid personKey);
    }
}
