using BenfeitorApi.Models;
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
        LoanResponse GetLoan(string id);
    }
}
