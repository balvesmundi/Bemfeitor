using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface ILoanService
    {
        LoanResponse CreateLoan(CreateLoanRequest request, long borrowerId, long lenderId);
        LoanResponse GetLoan(long id);
    }
}
