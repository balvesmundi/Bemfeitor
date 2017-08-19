using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BenfeitorApi.Models;
using BenfeitorApi.Services;
using Repository.Interfaces;

namespace BenfeitorApi.Controllers
{

    public class PersonController : ApiController
    {

        private IPersonService _personService;

        public PersonController(IPersonService personService)
        {


            this._personService = personService;

        }

        [HttpPost]
        [Route("accounts")]
        public IHttpActionResult CreateAccount(CreatePersonRequest request)
        {

            // TODO: Create account
            //_personService.CreateAccount(


            return this.GetAccount(new Guid());
        }

        [HttpGet]
        [Route("accounts/{id}")]
        public IHttpActionResult GetAccount(Guid personKey)
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
