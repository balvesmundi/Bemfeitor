//using System;
//using System.Linq;
//using System.Net.Http;
//using System.Threading;
//using System.Threading.Tasks;
//using System.Web.Cors;
//using System.Web.Http.Cors;

//namespace MundiPagg.Benfeitor.BenfeitorApi.Attributes
//{

//    public class ActionCorsAttribute : Attribute, ICorsPolicyProvider
//    {

//        public Task<CorsPolicy> GetCorsPolicyAsync(HttpRequestMessage request, CancellationToken cancellationToken)
//        {

//            var policy = new CorsPolicy();

//            //string origin = null;
//            //if (request.Headers.Contains("Origin"))
//            //{
//            //    origin = request.Headers.GetValues("Origin").First();

//            //    policy.Origins.Add(origin);
//            //}

//            policy.Origins.Add("*");
//            policy.Headers.Add("*");
//            policy.Methods.Add("*");

//            //policy.Headers.Add("Content-Type");
//            //policy.Headers.Add("Authorization");

//            //policy.Methods.Add("GET");
//            //policy.Methods.Add("POST");
//            //policy.Methods.Add("PUT");
//            //policy.Methods.Add("PATCH");
//            //policy.Methods.Add("DELETE");
//            //policy.Methods.Add("OPTIONS");

//            return Task.FromResult(policy);
//        }
//    }
//}