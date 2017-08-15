using Smafac.Framework.Core.Domain;
using Smafac.Framework.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Smafac.Framework.WebApi
{
    public class UserContextMessageHandler : DelegatingHandler
    {
        public const string UserContextExceptionKey = "ex_usercontext";

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var headers = request.Headers;
            var subscriberIdHeader = headers.SingleOrDefault(x => x.Key.ToLower() == "subscriberid");
            var userIdHeader = headers.SingleOrDefault(x => x.Key.ToLower() == "userid");
            if (string.IsNullOrEmpty(subscriberIdHeader.Key) || string.IsNullOrEmpty(userIdHeader.Key))
            {
                SetException(request);
                return base.SendAsync(request, cancellationToken);
            }
            Guid subscriberId = Guid.Empty;
            Guid userId = Guid.Empty;
            var subscriberIdString = subscriberIdHeader.Value.FirstOrDefault();
            var userIdString = userIdHeader.Value.FirstOrDefault();
            if (string.IsNullOrEmpty(subscriberIdString) || string.IsNullOrEmpty(userIdString))
            {
                SetException(request);
                return base.SendAsync(request, cancellationToken);
            }
            var parseSubscriberId = Guid.TryParse(subscriberIdString, out subscriberId);
            var parseUserId = Guid.TryParse(userIdString, out userId);
            if (!parseSubscriberId || !parseUserId)
            {
                SetException(request);
                return base.SendAsync(request, cancellationToken);
            }
            var userContext = new UserContext
            {
                SubscriberId = subscriberId,
                UserId = userId
            };
            Thread.CurrentPrincipal = new SmafacPrincipal { UserContext = userContext };
            return base.SendAsync(request, cancellationToken);
        }

        private void SetException(HttpRequestMessage request)
        {
            request.Properties["ex_usercontext"] = new Exception("用户信息不存在");
        }
    }
}
