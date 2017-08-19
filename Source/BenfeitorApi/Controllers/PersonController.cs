using System;
using System.Web.Http;
using MundiPagg.Benfeitor.BenfeitorApi.Models;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Seedwork.Exceptions;
using MundiPagg.Benfeitor.BenfeitorApi.Services;

namespace MundiPagg.Benfeitor.BenfeitorApi.Controllers
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
        [Route("accounts/{personKey}")]
        public IHttpActionResult GetAccount(Guid personKey)
        {
            try
            {
                var response = this._personService.GetPerson(personKey);

                return Ok(response);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPatch]
        [Route("accounts")]
        public IHttpActionResult UpdateAccount(CreatePersonRequest request)
        {

            Guid personKey = new Guid();

            var response = this._personService.UpdatePerson(personKey, request);

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
            catch (Exception ex)
            {
                return BadRequest();
            }

            return Ok();
        }
        
        //[HttpPost]
        //[Route("accounts")]
        //public IHttpActionResult Search(SearchRequest request)
        //{

        //    var response = this._personService.CreatePerson(request);

        //    return Ok(response);
        //}


        protected override void Dispose(bool disposing)
        {

            this._personService.Dispose();

            base.Dispose(disposing);
        }
    }
}
