using Smafac.Account.Subscriber.Applications;
using Smafac.Account.Subscriber.Models;
using Smafac.Framework.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Smafac.Account.Subscriber.WebApi.Controllers
{
    [UserContextFilter]
    public class SubscriberController : ApiController
    {
        private readonly ISubscriberService _subscriberService;

        public SubscriberController(ISubscriberService subscriberService)
        {
            _subscriberService = subscriberService;
        }

        [HttpPost]
        [AllowAnonymous]
        public bool Register(PassportModel model)
        {
            return _subscriberService.Register(model);
        }
    }
}