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
        private IChargeService _chargeService;

        public LoanService(ILoanRepository loanRepository, IPersonRepository personRepository, IChargeService chargeService)
        {

            this._loanRepository = loanRepository;
            this._personRepository = personRepository;
            this._chargeService = chargeService;
        }

        public LoanResponse CreateLoan(CreateLoanRequest request, long borrowerId, long lenderId)
        {

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {

                var chargeRequest = new CreateChargeRequest()
                {
                    AmountInCents = request.AmountInCents,
                    Code = new Random().Next(int.MaxValue).ToString(),
                    PayerPersonId = lenderId,
                    StatementDescriptor = "Emprestimo"
                };

                var chargeResponse = this._chargeService.CreateCharge(chargeRequest);

                var loanHistory = LoanMapper.MapLoanHistory(request, borrowerId, lenderId, chargeResponse.ChargeId);

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
            var loans = this._loanRepository.FindAll(
                p => p.Borrower.PersonKey == personKey || p.Lender.PersonKey == personKey,
                include => include.Borrower,
                include => include.Lender
                ).ToList();

            return LoanMapper.MapLoanHistoryResponse(loans);
        }

        #region IDisposable Members

        public void Dispose()
        {
            this._loanRepository.Dispose();
            this._chargeService.Dispose();
        }

        #endregion
    }
}