using System;
using MundiPagg.Benfeitor.Repository.Entities;

namespace MundiPagg.Benfeitor.Repository.Interfaces
{
    public interface IPersonRepository
    {

        void CreatePerson(Person person);

        Person GetPersonByKey(Guid personKey);
    }
}
