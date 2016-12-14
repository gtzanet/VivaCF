using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebApiViva2
{
    public  class BasicAuthenticationAttributes : AuthorizationFilterAttribute
    {
        private Encoding encoding { get; set; }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            encoding = Encoding.GetEncoding("iso-8859-1");
            try
            {
                if (actionContext.Request.Headers.GetCookies("token").FirstOrDefault() != null)
                {
                    string cookie_token = ReturnTokenFromCookie(actionContext);

                    if (Validation(actionContext, cookie_token))  return;
                }
            }
            catch (Exception ex)
            {
                HandleUnauthorizedRequest(actionContext);
            }

            var authHeader = actionContext.Request.Headers.Authorization;
            if (authHeader != null
                && !string.IsNullOrEmpty(authHeader.Parameter)
                && authHeader.Scheme.Equals("basic", StringComparison.OrdinalIgnoreCase))
            {
                if (Validation(actionContext, authHeader.Parameter)) return;
            }

            HandleUnauthorizedRequest(actionContext);
        }

        private string ReturnTokenFromCookie(HttpActionContext actionContext) {

            string cookie = actionContext.Request.Headers.GetCookies("token").FirstOrDefault().ToString();
            string[] cookie_split = cookie.Split(';');
            string cookie_token = "";

            if (cookie_split.Length > 1)
            {
                for (int i = 0; i < cookie_split.Length - 1; i++)
                {
                    string[] cookie_tmp = cookie_split[i].Split('=');
                    if (cookie_tmp[0] == "token")
                    {
                        return cookie_token = cookie_tmp[1];
                    }
                }
            }
            else
            {
                string[] cookie_tmp = cookie_split[0].Split('=');
                return cookie_token = cookie_tmp[1];
            }

            return "";
        }

        private Boolean Validation(HttpActionContext actionContext, string tmp )
        {
            var credentialstring = encoding.GetString(Convert.FromBase64String(tmp));
            var credentials = credentialstring.Split(':');
            var isValid = Validate(credentials[0], credentials[1]);

            if (isValid)
            {
                var identity = new GenericIdentity(credentials[0]);
                var principal = new GenericPrincipal(identity, null);
                Thread.CurrentPrincipal = principal;
                if (HttpContext.Current != null)
                {
                    HttpContext.Current.User = principal;
                }

                return true;
            }
            return false;
        }


        protected  void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            //Modify if required.     
              var realm = "DreamFountain";
            var result = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.Unauthorized,
                  RequestMessage = actionContext.ControllerContext.Request
              };

            result.Headers.Add("WWW-Authenticate",
                string.Format("Basic realm=\"{0}\"", realm));

                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }
        

        private bool Validate(string username, string password)
        {
            //Validate username and password against the Database     return true;

            if (UsersSecurity.Login(username, password))
            {
                UsersSecurity.SetUSerID(username, password);
  
                return true;
            }
            return false;
        }


    }




}