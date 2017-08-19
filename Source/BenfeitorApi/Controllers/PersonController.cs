using System;
using System.Web.Http;
using BenfeitorApi.Models;
using BenfeitorApi.Services;
using BenfeitorApi.Models.Request;

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

            var response = this._personService.CreatePerson(request);

            return Ok(response);
        }

        [HttpGet]
        [Route("accounts/{id}")]
        public IHttpActionResult GetAccount(Guid personKey)
        {

            var response = this._personService.GetPerson(personKey);

            return Ok(response);
        }

        [HttpPatch]
        [Route("accounts")]
        public IHttpActionResult GetAccount(CreatePersonRequest request)
        {

            var response = this._personService.PatchPerson(request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("accounts/{id}")]
        public IHttpActionResult DeleteAccount(Guid personKey)
        {

            try
            {
                this._personService.DeletePerson(personKey);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}
