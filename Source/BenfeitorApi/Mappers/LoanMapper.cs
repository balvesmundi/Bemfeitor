using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Aggregates.Entities;
using Domain.Aggregates.Enums;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;

namespace MundiPagg.Benfeitor.BenfeitorApi.Mappers
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
            LoanStatusEnum loanStatusEnum = LoanStatusEnum.Undefined;
            Enum.TryParse<LoanStatusEnum>(loanHistory.LoanStatusEnum, out loanStatusEnum);

            return new LoanResponse()
            {
                LoanHistoryId = loanHistory.LoanHistoryId,
                LoanStatusEnum = loanStatusEnum,
                
                AmountInCents = loanHistory.AmountInCents,
                DueDate = loanHistory.DueDate,
                TaxPerDay = loanHistory.TaxPerDay,

                LenderGrade = loanHistory.LenderGrade,
                BorrowerGrade = loanHistory.BorrowerGrade,
                CommentToBorrower = loanHistory.CommentToBorrower,
                CommentToLender = loanHistory.CommentToLender
            };
        }
    }
}