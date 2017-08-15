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
    public class PassportController : ApiController
    {
        private readonly IPassportService _passportService;

        public PassportController(IPassportService passportService)
        {
            _passportService = passportService;
        }
        [HttpPost]
        public bool CreatePassport(PassportModel model)
        {
            return _passportService.CreatePassport(model);
        }

        [AllowAnonymous]
        [HttpPost]
        public string Login(PassportModel model)
        {
            return _passportService.Login(model);
        }
    }
}