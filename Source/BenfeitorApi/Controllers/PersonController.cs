using System;
using System.Web.Http;
using System.Web.Http.Cors;
using MundiPagg.Benfeitor.BenfeitorApi.Attributes;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;
using MundiPagg.Benfeitor.BenfeitorApi.Seedwork.Exceptions;
using MundiPagg.Benfeitor.BenfeitorApi.Services;

namespace MundiPagg.Benfeitor.BenfeitorApi.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            try
            {
                var response = this._personService.CreatePerson(request);

                return Ok(response);
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpGet]
        [Route("accounts")]
        [ActionAuth]
        public IHttpActionResult GetMyAccount()
        {
            try
            {
                var person = this.Request.Properties["Person"] as PersonResponse;

                var response = this._personService.GetPerson(person.PersonKey);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpGet]
        [Route("accounts/{personKey}")]
        [ActionAuth]
        public IHttpActionResult GetAccount(Guid personKey)
        {
            try
            {
                var response = this._personService.GetOtherPerson(personKey);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("accounts")]
        [ActionAuth]
        public IHttpActionResult UpdateAccount(CreatePersonRequest request)
        {

            var person = this.Request.Properties["Person"] as PersonResponse;

            var response = this._personService.UpdatePerson(person.PersonKey, request);

            return Ok(response);
        }

        [HttpDelete]
        [Route("accounts/{personKey}")]
        [ActionAuth]
        public IHttpActionResult DeleteAccount(Guid personKey)
        {

            try
            {
                this._personService.DeletePerson(personKey);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }

        [HttpPost]
        [Route("accounts/search")]
        [ActionAuth]
        public IHttpActionResult Search(SearchRequest request)
        {

            var response = this._personService.Search(request);

            return Ok(response);
        }

        protected override void Dispose(bool disposing)
        {
            this._personService.Dispose();

            base.Dispose(disposing);
        }
    }
}
