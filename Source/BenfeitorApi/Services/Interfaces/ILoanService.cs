using BenfeitorApi.Models;
using BenfeitorApi.Models.Request;
using BenfeitorApi.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BenfeitorApi.Services
{
    public interface ILoanService
    {
        LoanResponse CreateLoan(CreateLoanRequest request);
        LoanResponse GetLoan(long id);
    }
}
