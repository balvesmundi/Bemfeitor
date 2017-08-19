using System;
using MundiPagg.Benfeitor.Repository.Entities;

namespace MundiPagg.Benfeitor.Repository.Interfaces
{
    public interface IPersonRepository
    {

        void CreatePerson(Person person);

        Person GetPerson(Guid personKey);

        long GetPersonId(Guid personKey);

        Person PatchPerson(Person personRequest);

        void DeletePerson(Guid personKey);
    }
}
