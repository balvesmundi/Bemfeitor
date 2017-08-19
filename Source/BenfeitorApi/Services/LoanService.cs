using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MundiPagg.Benfeitor.BenfeitorApi.Models;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public class LoanService : ILoanService
    {
        private ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {

            this._loanRepository = loanRepository;

        }

        public LoanResponse CreateLoan(CreateLoanRequest request)
        {
            // TODO: Create loan

            var id = "1";

            return this.GetLoan(id);
        }

        public LoanResponse GetLoan(string id)
        {
            throw new NotImplementedException();
        }
    }
}