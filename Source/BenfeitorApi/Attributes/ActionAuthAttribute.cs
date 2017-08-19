using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Net.Http;
using System.Net;
using System.Configuration;
using MundiPagg.Benfeitor.BenfeitorApi.Services;

namespace MundiPagg.Benfeitor.BenfeitorApi.Attributes
{

    public class ActionAuthAttribute : AuthorizeAttribute
    {

        readonly string[] _schemes = new string[] { "BEARER" };

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains("Authorization") == false) return false;

            var header = actionContext.Request.Headers.Authorization;
            var scheme = header.Scheme.ToUpper();
            if (_schemes.Contains(scheme) == false) return false;

            var authenticated = false;

            switch (scheme)
            {
                case "BEARER":
                    authenticated = this.AuthPersonWithBearer(header.Parameter, actionContext);
                    break;
                default:
                    authenticated = false;
                    break;
            }

            return authenticated;
        }

        /// <summary>
        /// Autorizar cliente
        /// </summary>
        /// <param name="header"></param>
        /// <param name="actionContext"></param>
        /// <returns></returns>
        bool AuthPersonWithBearer(string header, HttpActionContext actionContext)
        {
            var controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
            var action = actionContext.ActionDescriptor.ActionName;

            //var route = actionContext.RequestContext.RouteData;
            //var routeContainsCustomerId = route.Values.ContainsKey("customerId");

            //var queryString = actionContext.Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
            //var queryStringContainsCustomerId = queryString.ContainsKey("customer_id");

            //if (ActionAvailable(action, controller) == false) return false;
            //if (routeContainsCustomerId == false && queryStringContainsCustomerId == false) return false;

            try
            {

                using (var service = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAuthenticationService)) as IAuthenticationService)
                {

                    var person = service.GetPersonByBearerToken(header);

                    if (person == null) { return false; }

                    //var id = (routeContainsCustomerId) ? route.Values["customerId"] as string : queryString["customer_id"];

                    //if (token.Status.Equals("ACTIVE", StringComparison.InvariantCultureIgnoreCase) == false) return false;
                    //if (token.Customer.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase) == false) return false;
                    //if (token.Account.Status.Equals("ACTIVE", StringComparison.InvariantCultureIgnoreCase) == false) return false;

                    actionContext.Request.Properties.Add("Person", person);

                    return true;
                }

            }
            catch (Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Obter valor do header authorization com o esquema Basic
        /// </summary>
        /// <param name="header"></param>
        /// <returns></returns>
        string GetBasicHeaderValue(string header)
        {

            try
            {

                var value = Convert.FromBase64String(header);
                var credentials = Encoding.UTF8.GetString(value);
                var index = credentials.IndexOf(':');
                if (index == -1) return null;

                return credentials.Substring(0, index);

            }
            catch (Exception)
            {
                return null;
            }
        }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {

            base.HandleUnauthorizedRequest(actionContext);

            if (actionContext.Request.Headers.Contains("Authorization") == false) return;

            var header = actionContext.Request.Headers.Authorization;
            var value = new AuthenticationHeaderValue(header.Scheme);

            actionContext.Response.Headers.WwwAuthenticate.Add(value);
        }
    }
}