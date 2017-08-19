using System;
using System.Transactions;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        private IPersonRepository _personRepository;

        public AuthenticationService(IPersonRepository personRepository)
        {

            this._personRepository = personRepository;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest request)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var person = this._personRepository.FindOne(p => p.IsEnabled == true && p.Username == request.Username && p.Password == request.Password);

                if (person == null)
                {
                    return new AuthenticateResponse()
                    {
                        Success = false
                    };
                }

                person.BearerToken = Guid.NewGuid().ToString("N");

                this._personRepository.UnitOfWork.Commit();

                scope.Complete();

                return new AuthenticateResponse()
                {
                    Bearer = person.BearerToken,
                    Success = true
                };
            }
        }

        public PersonResponse GetPersonByBearerToken(string bearer)
        {

            var person = this._personRepository.FindOne(p => p.BearerToken == bearer);

            return PersonMapper.MapPersonResponse(person);
        }

        #region IDisposable Members

        public void Dispose()
        {
            this._personRepository.Dispose();
        }

        #endregion
    }
}