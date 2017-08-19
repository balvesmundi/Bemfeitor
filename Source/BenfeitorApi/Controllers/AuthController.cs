using System.Web.Http;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Services;

namespace MundiPagg.Benfeitor.BenfeitorApi.Controllers
{
    public class AuthController : ApiController
    {

        private IAuthenticationService _authenticationService;

        public AuthController(IAuthenticationService authenticationService)
        {
            this._authenticationService = authenticationService;
        }

        [HttpPost]
        [Route("auth")]
        public IHttpActionResult Authenticate(AuthenticateRequest request)
        {
            var response = this._authenticationService.Authenticate(request);

            if (response.Success)
            {
                return Ok(response);
            }
            else
            {
                return Unauthorized();
            }
        }

        protected override void Dispose(bool disposing)
        {

            this._authenticationService.Dispose();

            base.Dispose(disposing);
        }
    }
}
