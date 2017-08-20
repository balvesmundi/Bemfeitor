using System;
using System.Web.Http;
using System.Web.Http.Cors;
using MundiPagg.Benfeitor.BenfeitorApi.Attributes;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using MundiPagg.Benfeitor.BenfeitorApi.Services;

namespace MundiPagg.Benfeitor.BenfeitorApi.Controllers
{
    [ActionAuth]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LoanController : ApiController
    {

        private ILoanService _loanService;
        private IPersonService _personService;

        public LoanController(ILoanService loanService, IPersonService personService)
        {

            this._loanService = loanService;
            this._personService = personService;
        }


        [HttpPost]
        [Route("loans")]
        public IHttpActionResult CreateLoan(CreateLoanRequest request)
        {

            try
            {
                var borrowerId = _personService.GetPersonId(request.PersonBorrowerKey);
                var lenderId = _personService.GetPersonId(request.PersonLenderKey);
                var response = _loanService.CreateLoan(request, borrowerId, lenderId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("loans/{loanHistoryId}")]
        public IHttpActionResult GetLoan(long loanHistoryId)
        {

            var response = _loanService.GetLoan(loanHistoryId);

            return Ok(response);
        }

        [HttpGet]
        [Route("loans")]
        public IHttpActionResult GetMyLoans()
        {

            try
            {
                var person = this.Request.Properties["Person"] as PersonResponse;

                var response = this._loanService.GetMyLoans(person.PersonKey);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        protected override void Dispose(bool disposing)
        {

            this._loanService.Dispose();
            this._personService.Dispose();

            base.Dispose(disposing);
        }
    }
}