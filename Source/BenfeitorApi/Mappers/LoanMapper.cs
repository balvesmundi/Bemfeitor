using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Aggregates.Entities;
using Domain.Aggregates.Enums;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;

namespace MundiPagg.Benfeitor.BenfeitorApi.Mappers
{
    public static class LoanMapper
    {
        public static LoanHistory MapLoanHistory(CreateLoanRequest request, long borrowerId, long lenderId, long chargeId)
        {

            return new LoanHistory()
            {
                AmountInCents = request.AmountInCents,
                DueDate = request.DueDate,
                LoanStatusEnum = LoanStatusEnum.PendingLenderMoney.ToString(),
                TaxPerDay = request.TaxPerDay,
                CreateDate = DateTime.UtcNow,
                PersonBorrowerId = borrowerId,
                PersonLenderId = lenderId,
                ChargeId = chargeId,
                LoanReason = request.LoanReason
            };
        }

        public static LoanResponse MapLoanHistoryResponse(LoanHistory loanHistory)
        {
            LoanStatusEnum loanStatusEnum = LoanStatusEnum.Undefined;
            Enum.TryParse<LoanStatusEnum>(loanHistory.LoanStatusEnum, out loanStatusEnum);

            return new LoanResponse()
            {
                LoanHistoryId = loanHistory.LoanHistoryId,
                LoanStatusEnum = loanStatusEnum.ToString(),

                AmountInCents = loanHistory.AmountInCents,
                DueDate = loanHistory.DueDate,
                TaxPerDay = loanHistory.TaxPerDay,
                LoanReason = loanHistory.LoanReason,

                LenderGrade = loanHistory.LenderGrade,
                BorrowerGrade = loanHistory.BorrowerGrade,
                CommentToBorrower = loanHistory.CommentToBorrower,
                CommentToLender = loanHistory.CommentToLender,

                LenderName = loanHistory.Lender?.Name,
                BorrowerName = loanHistory.Borrower?.Name
            };
        }

        public static List<LoanResponse> MapLoanHistoryResponse(List<LoanHistory> loanHistories)
        {
            if (loanHistories == null) return null;

            var loanResponses = new List<LoanResponse>();
            foreach (var loan in loanHistories)
            {
                loanResponses.Add(MapLoanHistoryResponse(loan));
            }
            return loanResponses;
        }
    }
}