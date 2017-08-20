using System;
using System.Linq;
using Infrastructure.Payment.Contracts;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;

namespace MundiPagg.Benfeitor.BenfeitorApi.Mappers
{
    public class RecipientMapper
    {

        public static CreateRecipientRequestDTO MapCreateRecipientRequestDTO(CreateRecipientRequest request)
        {

            return new CreateRecipientRequestDTO()
            {
                DefaultBankAccount = new DefaultBankAccountRequestDTO()
                {
                    AccountCheckDigit = request.RecipientBankAccount.AccountCheckDigit,
                    AccountNumber = request.RecipientBankAccount.AccountNumber,
                    Bank = request.RecipientBankAccount.Bank,
                    BranchCheckDigit = request.RecipientBankAccount.BranchCheckDigit,
                    BranchNumber = request.RecipientBankAccount.BranchNumber,
                    HolderDocument = request.RecipientBankAccount.HolderDocument,
                    HolderName = request.RecipientBankAccount.HolderName,
                    HolderType = request.RecipientBankAccount.HolderType,
                    Type = request.RecipientBankAccount.Type
                },
                Description = request.Description,
                Document = request.Document,
                Email = request.Email,
                Name = request.Name,
                Type = request.Type
            };
        }

        public static RecipientResponse MapRecipientResponse(CreateRecipientResponseDTO response)
        {

            return new RecipientResponse()
            {
                CreatedAt = response.CreatedAt,
                Description = response.Description,
                Document = response.Document,
                Email = response.Email,
                Id = response.Id,
                Name = response.Name,
                RecipientBankAccount = new RecipientBankAccountResponse()
                {
                    AccountCheckDigit = response.DefaultBankAccount.AccountCheckDigit,
                    AccountNumber = response.DefaultBankAccount.AccountNumber,
                    Bank = response.DefaultBankAccount.Bank,
                    BranchCheckDigit = response.DefaultBankAccount.BranchCheckDigit,
                    BranchNumber = response.DefaultBankAccount.AccountCheckDigit,
                    CreatedAt = response.DefaultBankAccount.CreatedAt,
                    HolderDocument = response.DefaultBankAccount.HolderDocument,
                    HolderName = response.DefaultBankAccount.HolderName,
                    HolderType = response.DefaultBankAccount.HolderType,
                    Id = response.DefaultBankAccount.Id,
                    Status = response.DefaultBankAccount.Status,
                    Type = response.DefaultBankAccount.Type,
                    UpdatedAt = response.DefaultBankAccount.UpdatedAt
                },
                Status = response.Status,
                Type = response.Type,
                UpdatedAt = response.UpdatedAt
            };
        }

        public static CreateRecipientRequest MapCreateRecipientRequest(CreatePersonRequest request)
        {

            return new CreateRecipientRequest()
            {
                Description = request.Name,
                Document = request.Documents.FirstOrDefault().DocumentNumber,
                Email = request.Email,
                Name = request.Name,
                RecipientBankAccount = new CreateRecipientBankAccountRequest()
                {
                    AccountCheckDigit = request.BankAccount.AccountCheckDigit,
                    AccountNumber = request.BankAccount.AccountNumber,
                    Bank = request.BankAccount.Bank,
                    BranchCheckDigit = request.BankAccount.BranchCheckDigit,
                    BranchNumber = request.BankAccount.BranchNumber,
                    HolderDocument = request.Documents.FirstOrDefault().DocumentNumber,
                    HolderName = request.Name,
                    HolderType = "individual",
                    Type = "checking"
                },
                Type = "individual"
            };
        }

        //public static CreateRecipientRequest MapCreateRecipientRequest(CreatePersonRequest request)
        //{

        //    return new CreateRecipientRequest()
        //    {
        //        Description = request.Name,
        //        Document = request.Documents.FirstOrDefault().DocumentNumber,
        //        Email = request.Email,
        //        Name = request.Name,
        //        RecipientBankAccount = new CreateRecipientBankAccountRequest()
        //        {
        //            AccountCheckDigit = request.BankAccount.AccountCheckDigit,
        //            AccountNumber = request.BankAccount.AccountNumber,
        //            Bank = request.BankAccount.Bank,
        //            BranchCheckDigit = request.BankAccount.BranchCheckDigit,
        //            BranchNumber = request.BankAccount.BranchNumber,
        //            HolderDocument = request.BankAccount.HolderDocument,
        //            HolderName = request.BankAccount.HolderName,
        //            HolderType = request.BankAccount.HolderType,
        //            Type = request.BankAccount.Type
        //        },
        //        Type = "individual"
        //    };
        //}

    }
}