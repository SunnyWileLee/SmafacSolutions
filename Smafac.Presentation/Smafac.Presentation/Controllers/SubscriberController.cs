using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Smafac.Account.Subscriber.Applications;
using Smafac.Account.Subscriber.Models;
using Smafac.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Smafac.Presentation.Controllers
{
    public class SubscriberController : SmafacController
    {
        private readonly IPassportService _passportService;
        public UserManager<SmafacUser> UserManager { get; private set; }

        public SubscriberController(IPassportService passportService)
        {
            _passportService = passportService;
            UserManager = new UserManager<SmafacUser>(new UserStore());
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult SignInView()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> SignIn(PassportModel model)
        {
            var passportId = _passportService.SignIn(model);
            if (passportId == Guid.Empty)
            {
                return Fail(-1, "用户名或密码错误");
            }
            model.Id = passportId;
            await SignInAsync(new SmafacUser(model), true);
            return Success(model);
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private async Task SignInAsync(SmafacUser user, bool isPersistent)
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            var identity = await UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            AuthenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        [HttpGet]
        public ActionResult MainView()
        {
            return View();
        }
    }
}