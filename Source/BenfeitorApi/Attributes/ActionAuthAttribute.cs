//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http.Headers;
//using System.Text;
//using System.Web;
//using System.Web.Http;
//using System.Web.Http.Controllers;
//using System.Net.Http;
//using System.Net;
//using System.Configuration;

//namespace MundiPagg.Benfeitor.BenfeitorApi.Attributes
//{

//    public class ActionAuthAttribute : AuthorizeAttribute
//    {

//        readonly string _scope;
//        readonly string _key;
//        readonly string[] _schemes = new string[] { "BASIC", "BEARER" };

//        public ActionAuthAttribute(string scope = "ACCOUNT", string acctKey = "PRIVATE")
//        {
//            _scope = scope.ToUpper();
//            _key = acctKey.ToUpper();
//        }

//        protected override bool IsAuthorized(HttpActionContext actionContext)
//        {

//            if (actionContext.Request.Headers.Contains("Authorization") == false) return false;

//            var header = actionContext.Request.Headers.Authorization;
//            var scheme = header.Scheme.ToUpper();
//            if (_schemes.Contains(scheme) == false) return false;

//            var authenticated = false;

//            switch (scheme)
//            {
//                case "BEARER":
//                    authenticated = AuthPersonWithBearer(header.Parameter, actionContext);
//                    break;
//                case "BASIC":

//                    switch (_scope)
//                    {
//                        case "ACCOUNT":
//                            authenticated = AuthPersonWithPassword(header.Parameter, actionContext);
//                            break;
//                        default:
//                            authenticated = false;
//                            break;
//                    }

//                    break;
//            }

//            return authenticated;
//        }

//        /// <summary>
//        /// Autorizar cliente
//        /// </summary>
//        /// <param name="header"></param>
//        /// <param name="actionContext"></param>
//        /// <returns></returns>
//        bool AuthPersonWithBearer(string header, HttpActionContext actionContext)
//        {

//            var controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName;
//            var action = actionContext.ActionDescriptor.ActionName;

//            var route = actionContext.RequestContext.RouteData;
//            var routeContainsCustomerId = route.Values.ContainsKey("customerId");

//            var queryString = actionContext.Request.GetQueryNameValuePairs().ToDictionary(x => x.Key, x => x.Value);
//            var queryStringContainsCustomerId = queryString.ContainsKey("customer_id");

//            if (ActionAvailable(action, controller) == false) return false;
//            if (routeContainsCustomerId == false && queryStringContainsCustomerId == false) return false;

//            try
//            {

//                using (var service = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(ICustomerAppService)) as ICustomerAppService)
//                {

//                    var token = service.GetAccessTokenByCode(header);

//                    var id = (routeContainsCustomerId) ? route.Values["customerId"] as string : queryString["customer_id"];

//                    if (token.Status.Equals("ACTIVE", StringComparison.InvariantCultureIgnoreCase) == false) return false;
//                    if (token.Customer.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase) == false) return false;
//                    if (token.Account.Status.Equals("ACTIVE", StringComparison.InvariantCultureIgnoreCase) == false) return false;

//                    actionContext.Request.Properties.Add("Account", token.Account);

//                    return true;
//                }

//            }
//            catch (KeyNotFoundException)
//            {
//                return false;
//            }
//            catch (Exception e)
//            {

//                var log = new ApiLoggable<string>()
//                {
//                    Controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName,
//                    Environment = ConfigurationManager.AppSettings["log:Environment"],
//                    MessageType = "Authentication Error",
//                    Operation = actionContext.ActionDescriptor.ActionName,
//                    Version = ConfigurationManager.AppSettings["version"],
//                    Exception = e,
//                    LogTemplate = "[{Application}: {Operation}] {MessageType} in {Operation})",
//                    RequestKey = AppCycle.Id,
//                    Url = actionContext.Request.RequestUri.ToString(),
//                    Headers = Utility.GetHeaders(),
//                    StatusCode = actionContext.Response.StatusCode
//                };

//                Logger.WriteError(
//                        app: "MERCH-API",
//                        log: log,
//                        type: LogType.Error
//                    );

//                return false;
//            }
//        }

//        /// <summary>
//        /// Autorizar conta
//        /// </summary>
//        /// <param name="header"></param>
//        /// <param name="actionContext"></param>
//        /// <returns></returns>
//        bool AuthPersonWithPassword(string header, HttpActionContext actionContext)
//        {

//            var key = GetBasicHeaderValue(header);
//            if (string.IsNullOrEmpty(key)) return false;

//            try
//            {

//                using (var service = GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(IAccountAppService)) as IAccountAppService)
//                {
//                    var account = service.GetAccountBySecretKey(key);
//                    if (account.Status.Equals("ACTIVE", StringComparison.InvariantCultureIgnoreCase) == false) return false;
//                    actionContext.Request.Properties.Add("Account", account);
//                    return true;
//                }

//            }
//            catch (KeyNotFoundException)
//            {
//                return false;
//            }
//            catch (Exception e)
//            {

//                var log = new ApiLoggable<string>()
//                {
//                    Controller = actionContext.ControllerContext.ControllerDescriptor.ControllerName,
//                    Environment = ConfigurationManager.AppSettings["log:Environment"],
//                    MessageType = "Authentication Error",
//                    Operation = actionContext.ActionDescriptor.ActionName,
//                    Version = ConfigurationManager.AppSettings["version"],
//                    Exception = e,
//                    LogTemplate = "[{Application}: {Operation}] {MessageType} in {Operation})",
//                    RequestKey = AppCycle.Id,
//                    Url = actionContext.Request.RequestUri.ToString(),
//                    Headers = Utility.GetHeaders(),
//                    StatusCode = actionContext.Response?.StatusCode ?? HttpStatusCode.InternalServerError
//                };

//                Logger.WriteError(
//                        app: "MERCH-API",
//                        log: log,
//                        type: LogType.Error
//                    );

//                return false;
//            }
//        }

//        /// <summary>
//        /// Obter valor do header authorization com o esquema Basic
//        /// </summary>
//        /// <param name="header"></param>
//        /// <returns></returns>
//        string GetBasicHeaderValue(string header)
//        {

//            try
//            {

//                var value = Convert.FromBase64String(header);
//                var credentials = Encoding.UTF8.GetString(value);
//                var index = credentials.IndexOf(':');
//                if (index == -1) return null;

//                return credentials.Substring(0, index);

//            }
//            catch (Exception)
//            {
//                return null;
//            }
//        }

//        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
//        {

//            base.HandleUnauthorizedRequest(actionContext);

//            if (actionContext.Request.Headers.Contains("Authorization") == false) return;

//            var header = actionContext.Request.Headers.Authorization;
//            var value = new AuthenticationHeaderValue(header.Scheme);

//            actionContext.Response.Headers.WwwAuthenticate.Add(value);
//        }
//    }
//}