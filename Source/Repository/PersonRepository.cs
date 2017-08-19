using System;
using System.Linq;
using Dlp.Connectors;
using MundiPagg.Benfeitor.Repository.Entities;
using MundiPagg.Benfeitor.Repository.Interfaces;

namespace MundiPagg.Benfeitor.Repository
{
    public class PersonRepository : BaseRepository, IPersonRepository
    {

        public void CreatePerson(Person person)
        {

            string query =
@"
DECLARE @TempId TABLE (Id BIGINT NOT NULL);
INSERT INTO [dbo].[Person]
	([PersonKey]
	,[CreateDate]
	,[Email]
	,[Name]
	,[FacebookId]
	,[TwitterId]
	,[GenderEnum]
	,[MobilePhone]
	,[HomePhone]
	,[WorkPhone]
	,[BirthDate]
	,[BalanceInCents]
	,[LoanTypeEnum]
	,[LoanInCents]
	,[DueDate]
	,[TaxPerDay])
OUTPUT PersonId INTO @TempId
VALUES
	(@PersonKey
	,@CreateDate
	,@Email
	,@Name
	,@FacebookId
	,@TwitterId
	,@GenderEnum
	,@MobilePhone
	,@HomePhone
	,@WorkPhone
	,@BirthDate
	,@BalanceInCents
	,@LoanTypeEnum
	,@LoanInCents
	,@DueDate
	,@TaxPerDay);
SELECT Id FROM @TempId;
";

            using (var database = new DatabaseConnector(this.ConnectionString))
            {
                long personId = database.ExecuteScalar<long>(query, person);

                person.PersonId = personId;

                if (person.Address != null)
                {
                    person.Address.PersonId = personId;
                    this.CreateAddress(person.Address);
                }
            }
        }

        public void CreateAddress(Address address)
        {

            string query =
@"
DECLARE @TempId TABLE (Id BIGINT NOT NULL);
INSERT INTO [dbo].[Address]
	([PersonId]
	,[Country]
	,[State]
	,[City]
	,[District]
	,[Street]
	,[Number]
	,[Complement]
	,[ZipCode])
OUTPUT AddressId INTO @TempId
VALUES
	(@PersonId
	,@Country
	,@State
	,@City
	,@District
	,@Street
	,@Number
	,@Complement
	,@ZipCode);
SELECT Id FROM @TempId;
";

            using (var database = new DatabaseConnector(this.ConnectionString))
            {
                long addressId = database.ExecuteScalar<long>(query, address);

                address.PersonId = addressId;
            }
        }

        public Person GetPersonByKey(Guid personKey)
        {

            string query =
@"SELECT [PersonId]
    ,[PersonKey]
    ,[CreateDate]
    ,[Email]
    ,[Name]
    ,[FacebookId]
    ,[TwitterId]
    ,[GenderEnum]
    ,[MobilePhone]
    ,[HomePhone]
    ,[WorkPhone]
    ,[BirthDate]
    ,[BalanceInCents]
    ,[LoanTypeEnum]
    ,[LoanInCents]
    ,[DueDate]
    ,[TaxPerDay]
FROM [dbo].[Person]
WHERE PersonKey = @PersonKey";

            using (var database = new DatabaseConnector(this.ConnectionString))
            {
                var person = database.ExecuteReader<Person>(query, new { PersonKey = personKey }).FirstOrDefault();

                person.Address = this.GetAddressByPersonId(person.PersonId);

                return person;
            }
        }

        public Address GetAddressByPersonId(long personId)
        {

            string query =
@"SELECT [AddressId]
    ,[PersonId]
    ,[Country]
    ,[State]
    ,[City]
    ,[District]
    ,[Street]
    ,[Number]
    ,[Complement]
    ,[ZipCode]
FROM [dbo].[Address]
WHERE PersonId = @PersonId";

            using (var database = new DatabaseConnector(this.ConnectionString))
            {
                return database.ExecuteReader<Address>(query, new { PersonId = personId }).FirstOrDefault();
            }
        }

        public long GetPersonId(Guid personKey)
        {
            throw new NotImplementedException();
        }

        public Person GetPerson(Guid personKey)
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
