using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public class LoanService : ILoanService
    {
        private ILoanRepository _loanRepository;
        private IPersonRepository _personRepository;

        public LoanService(ILoanRepository loanRepository, IPersonRepository personRepository)
        {

            this._loanRepository = loanRepository;
            this._personRepository = personRepository;
        }

        public LoanResponse CreateLoan(CreateLoanRequest request, long borrowerId, long lenderId)
        {

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                var loanHistory = LoanMapper.MapLoanHistory(request, borrowerId, lenderId);

                this._loanRepository.Add(loanHistory);

                this._loanRepository.UnitOfWork.Commit();

                //Atualiza CountAsBorrower e CountAsLender
                var lender = this._personRepository.FindOne(p => p.PersonId == lenderId);
                lender.CountAsLender++;
                this._personRepository.UnitOfWork.Commit();

                var borrower = this._personRepository.FindOne(p => p.PersonId == borrowerId);
                borrower.CountAsBorrower++;
                this._personRepository.UnitOfWork.Commit();

                scope.Complete();
                return LoanMapper.MapLoanHistoryResponse(loanHistory);
            }
        }

        public LoanResponse GetLoan(long id)
        {
            var loan = this._loanRepository.FindOne(p => p.LoanHistoryId == id);

            return LoanMapper.MapLoanHistoryResponse(loan);
        }

        public List<LoanResponse> GetMyLoans(Guid personKey)
        {
            var loans = this._loanRepository.FindAll(p => p.Borrower.PersonKey == personKey || p.Lender.PersonKey == personKey).ToList();

            return LoanMapper.MapLoanHistoryResponse(loans);
        }

        #region IDisposable Members

        public void Dispose()
        {
            this._loanRepository.Dispose();
        }

        #endregion
    }
}