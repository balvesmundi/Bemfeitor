using BenfeitorApi.Models;
using BenfeitorApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BenfeitorApi.Controllers
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


            return this.GetLoan(new Guid());
        }

        [HttpGet]
        [Route("loans/{id}")]
        public IHttpActionResult GetLoan(Guid personKey)
        {

            var response = new PersonResponse()
            {
                PersonKey = personKey,
                //Name = request.Name
            };

            return Ok(response);
        }
    }
}