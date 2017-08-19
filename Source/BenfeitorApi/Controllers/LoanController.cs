using BenfeitorApi.Models;
using BenfeitorApi.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Services;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;

namespace MundiPagg.Benfeitor.BenfeitorApi.Controllers
{
    public class LoanController : ApiController
    {

        private ILoanService _loanService;

        public LoanController(ILoanService loanService)
        {

            this._loanService = loanService;

        }

        [HttpPost]
        [Route("loan")]
        public IHttpActionResult CreateLoan(CreateLoanRequest request)
        {
            
            var response = _loanService.CreateLoan(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("loans/{id}")]
        public IHttpActionResult GetLoan(long loanHistoryId)
        {

            var response = _loanService.GetLoan(loanHistoryId);

            return Ok(response);
        }
    }
}