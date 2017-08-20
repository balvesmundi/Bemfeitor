using System;
using System.Transactions;
using Domain.Aggregates.Entities;
using Infrastructure.Payment.Seedwork;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public class ChargeService : IChargeService
    {

        private IPaymentFactory _paymentFactory;
        private IPersonRepository _personRepository;
        private IChargeRepository _chargeRepository;

        public ChargeService(IPaymentFactory paymentFactory, IPersonRepository personRepository, IChargeRepository chargeRepository)
        {
            this._paymentFactory = paymentFactory;
            this._personRepository = personRepository;
            this._chargeRepository = chargeRepository;
        }

        public ChargeResponse CreateCharge(CreateChargeRequest request)
        {

            var person = this._personRepository.FindOne(p => p.PersonId == request.PayerPersonId);

            var charge = new Charge()
            {
                AmountInCents = request.AmountInCents,
                Code = request.Code,
                CreateDate = DateTime.UtcNow,
                Payer = person,
                Status = "created"
            };

            using (var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                this._chargeRepository.Add(charge);

                this._chargeRepository.UnitOfWork.Commit();

                var payment = this._paymentFactory.Create();

                var requestDTO = ChargeMapper.MapCreateChargeRequestDTO(request, person);

                var response = payment.CreateCharge(requestDTO);

                charge.GatewayId = response.GatewayId;
                charge.Status = response.Status;

                this._chargeRepository.UnitOfWork.Commit();

                scope.Complete();

                return ChargeMapper.MapChargeResponse(response, charge.ChargeId);
            }
        }

        #region IDisposable Members

        public void Dispose()
        {

            this._personRepository.Dispose();
            this._chargeRepository.Dispose();
        }

        #endregion
    }
}