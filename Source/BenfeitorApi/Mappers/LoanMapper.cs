using BenfeitorApi.Models;
using BenfeitorApi.Models.Request;
using BenfeitorApi.Models.Response;
using Repository.Entities;
using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenfeitorApi.Mappers
{
    public static class LoanMapper
    {
        public static LoanHistory MapLoanHistory(CreateLoanRequest request, long borrowerId, long lenderId)
        {

            return new LoanHistory()
            {
                AmountInCents = request.AmountInCents,
                DueDate = request.DueDate,
                LoanStatusEnum = LoanStatusEnum.PendingLenderMoney.ToString(),
                TaxPerDay = request.TaxPerDay,
                CreateDate = DateTime.UtcNow,
                PersonBorrowerId = borrowerId,
                PersonLenderId = lenderId
            };
        }

        public static LoanResponse MapLoanHistoryResponse(LoanHistory loanHistory)
        {
            return new LoanResponse()
            {

            };
        }
    }
}