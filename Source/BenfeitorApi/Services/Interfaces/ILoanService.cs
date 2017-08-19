using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MundiPagg.Benfeitor.BenfeitorApi.Models;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public interface ILoanService
    {
        LoanResponse CreateLoan(CreateLoanRequest request);
        LoanResponse GetLoan(long id);
    }
}
