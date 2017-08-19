using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BenfeitorApi.Models;

namespace BenfeitorApi.Controllers
{

    public class AccountController : ApiController
    {

        [HttpPost]
        [Route("accounts")]
        public IHttpActionResult CreateAccount(CreateAccountRequest request)
        {

            var response = new AccountResponse()
            {
                Id = "1",
                Name = request.Name
            };

            return Ok(response);
        }

    }
}
