using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Services;

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

            // TODO: Create loan
            //_loanService.CreateLoan(


            return this.GetLoan(new long());
        }

        [HttpGet]
        [Route("loans/{id}")]
        public IHttpActionResult GetLoan(long loanHistoryId)
        {

            var response = new LoanResponse()
            {
                
                //Name = request.Name
            };

            return Ok(response);
        }
    }
}