using Smafac.ServiceCenter.Core.Applications;
using Smafac.ServiceCenter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Smafac.ServiceCenter.WebApi.Controllers
{
    public class RegisterController : ApiController
    {
        private readonly IServiceRegister _serviceRegister;

        public RegisterController(IServiceRegister serviceRegister)
        {
            _serviceRegister = serviceRegister;
        }

        [HttpPost]
        public bool Register(ApiCollectionModel model)
        {
            return _serviceRegister.Register(model.Service, model.Apis);
        }
    }
}