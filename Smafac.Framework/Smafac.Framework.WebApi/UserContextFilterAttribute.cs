using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Smafac.Framework.WebApi
{
    public class UserContextFilterAttribute : AuthorizationFilterAttribute
    {
        private Exception GetException(HttpRequestMessage request)
        {
            if (!request.Properties.ContainsKey(UserContextMessageHandler.UserContextExceptionKey))
            {
                return null;
            }
            return (Exception)request.Properties[UserContextMessageHandler.UserContextExceptionKey];
        }

        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.ActionDescriptor.GetCustomAttributes<AllowAnonymousAttribute>().Any())
            {
                return;
            }
            var ex = GetException(actionContext.Request);
            if (ex == null)
            {
                return;
            }
            var response = BuildResponse(ex);
            actionContext.Response = response;
        }

        private HttpResponseMessage BuildResponse(Exception ex)
        {
            var resultModel = ApiResponseModel.Fail(ex.Message);
            return new HttpResponseMessage
            {
                StatusCode =  HttpStatusCode.BadRequest,
                Content = new ObjectContent<ApiResponseModel>(resultModel, new JsonMediaTypeFormatter(),"application/json")
            };
        }
    }
}