using Microsoft.AspNet.Identity;
using Smafac.Account.Subscriber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smafac.Presentation.Models
{
    public class SmafacUser : IUser
    {
        private readonly PassportModel _passport;
        private string _username;
        public SmafacUser(PassportModel passport)
        {
            _passport = passport;
            _username = string.Format("{0};{1}",_passport.SubscriberId.ToString(), _passport.Id.ToString());
        }
        public string Id
        {
            get
            {
                return _passport.SubscriberId.ToString();
            }
        }

        public string UserName
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
            }
        }
    }
}