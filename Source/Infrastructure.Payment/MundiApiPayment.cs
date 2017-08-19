using Infrastructure.Payment.Contracts;
using Infrastructure.Payment.MundiApi.Contracts;
using Newtonsoft.Json;
using RestSharp;

namespace Infrastructure.Payment
{
    public class MundiApiPayment
    {

        public CreateRecipientResponseDTO CreateRecipient(CreateRecipientRequestDTO requestDTO)
        {

            var request = new CreateRecipientRequest()
            {
                default_bank_account = new DefaultBankAccountRequest()
                {
                    account_check_digit = requestDTO.DefaultBankAccount.AccountCheckDigit,
                    account_number = requestDTO.DefaultBankAccount.AccountNumber,
                    bank = requestDTO.DefaultBankAccount.Bank,
                    branch_check_digit = requestDTO.DefaultBankAccount.BranchCheckDigit,
                    branch_number = requestDTO.DefaultBankAccount.BranchNumber,
                    holder_document = requestDTO.DefaultBankAccount.HolderDocument,
                    holder_name = requestDTO.DefaultBankAccount.HolderName,
                    holder_type = requestDTO.DefaultBankAccount.HolderType,
                    type = requestDTO.DefaultBankAccount.Type
                },
                description = requestDTO.Description,
                document = requestDTO.Document,
                email = requestDTO.Email,
                name = requestDTO.Name,
                type = requestDTO.Type
            };

            var restRequest = new RestRequest("/core/v1/recipients");
            restRequest.AddParameter("application/json", JsonConvert.SerializeObject(request), ParameterType.RequestBody);
            var client = new RestClient("https://api.mundipagg.com");
            var restResponse = client.Post(restRequest);
            var response = JsonConvert.DeserializeObject<CreateRecipientResponse>(restResponse.Content);

            return new CreateRecipientResponseDTO()
            {
                Created_at = response.created_at,
                DefaultBankAccount = new DefaultBankAccountResponseDTO()
                {
                    AccountCheckDigit = response.default_bank_account.account_check_digit,
                    AccountNumber = response.default_bank_account.account_number,
                    Bank = response.default_bank_account.bank,
                    BranchCheckDigit = response.default_bank_account.branch_check_digit,
                    BranchNumber = response.default_bank_account.branch_number,
                    CreatedAt = response.default_bank_account.created_at,
                    HolderDocument = response.default_bank_account.holder_document,
                    HolderName = response.default_bank_account.holder_name,
                    HolderType = response.default_bank_account.holder_type,
                    Id = response.default_bank_account.id,
                    Status = response.default_bank_account.status,
                    Type = response.default_bank_account.type,
                    UpdatedAt = response.default_bank_account.updated_at,
                },
                Description = response.description,
                Document = response.document,
                Email = response.email,
                Id = response.id,
                Name = response.name,
                Status = response.status,
                Type = response.type,
                Updated_at = response.updated_at
            };
        }



    }
}
