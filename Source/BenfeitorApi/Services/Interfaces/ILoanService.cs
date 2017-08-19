using System;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using System.Collections.Generic;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface ILoanService : IDisposable
    {
        LoanResponse CreateLoan(CreateLoanRequest request, long borrowerId, long lenderId);
        LoanResponse GetLoan(long id);
        List<LoanResponse> GetMyLoans(Guid personKey);
    }
}
