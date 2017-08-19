using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.Repository.Entities;
using MundiPagg.Benfeitor.Repository.Enums;

namespace MundiPagg.Benfeitor.BenfeitorApi.Mappers
{
    public static class LoanMapper
    {
        public static LoanHistory MapLoanHistory(CreateLoanRequest request)
        {

            return new LoanHistory()
            {
                AmountInCents = request.AmountInCents,
                DueDate = request.DueDate,
                LoanStatusEnum = LoanStatusEnum.PendingLenderMoney.ToString(),
                TaxPerDay = request.TaxPerDay,
                CreateDate = DateTime.UtcNow,
                PersonBorrowerId = request.PersonBorrowerId,
                PersonLenderId = request.PersonLenderId
            };
        }
    }
}