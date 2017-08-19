using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public class LoanService : ILoanService
    {
        private ILoanRepository _loanRepository;

        public LoanService(ILoanRepository loanRepository)
        {

            this._loanRepository = loanRepository;
        }

        public LoanResponse CreateLoan(CreateLoanRequest request, long borrowerId, long lenderId)
        {

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                // TODO: Create loan
                //    var loanHistory = LoanMapper.MapLoanHistory(request);
                var loanHistory = LoanMapper.MapLoanHistory(request, borrowerId, lenderId);

                this._loanRepository.Add(loanHistory);

                this._loanRepository.UnitOfWork.Commit();

                scope.Complete();

                return LoanMapper.MapLoanHistoryResponse(loanHistory);
            }
        }

        public LoanResponse GetLoan(long id)
        {
            //var loan = this._loanRepository.GetLoanHistory(id);
            var loan = this._loanRepository.FindOne(p => p.LoanHistoryId == id);

            return LoanMapper.MapLoanHistoryResponse(loan);
        }
    }
}