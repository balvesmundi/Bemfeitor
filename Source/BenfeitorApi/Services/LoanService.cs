﻿using System;
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
            var loanHistory = LoanMapper.MapLoanHistory(request);

            this._loanRepository.CreateLoanHistory(loanHistory);

            return LoanMapper.MapLoanHistoryResponse(loanHistory);
        }

        public LoanResponse GetLoan(long id)
        {
            throw new NotImplementedException();
        }
    }
}