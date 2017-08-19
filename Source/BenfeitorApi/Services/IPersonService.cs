using BenfeitorApi.Models;

namespace BenfeitorApi.Services
{
    public interface IPersonService
    {
        PersonResponse CreateAccount(CreatePersonRequest request);
        PersonResponse GetAccount(string id);
    }
}