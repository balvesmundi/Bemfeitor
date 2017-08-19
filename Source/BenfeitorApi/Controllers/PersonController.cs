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

            
            return this.GetAccount("1");
        }

        [HttpGet]
        [Route("accounts/{id}")]
        public IHttpActionResult GetAccount(string id)
        {

            var response = new PersonResponse()
            {
                Id = id,
                //Name = request.Name
            };

            return Ok(response);
        }
    }
}
