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

        public Person PatchPerson(Person personRequest)
        {
            #warning Verificar dados nulos pra não atualizar no cadastro e retornar o Person todo
            throw new NotImplementedException();
        }

        public void DeletePerson(Guid personKey)
        {
            #warning apenas desabilitar pessoa
            throw new NotImplementedException();
        }
    }
}
