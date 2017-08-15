using AutoMapper;
using Smafac.Account.Subscriber.Applications;
using Smafac.Account.Subscriber.Models;
using Smafac.Account.Subscriber.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smafac.Account.Subscriber.Services
{
    class SignInService : ISignInService
    {
        private readonly ISignInRepository _signInRepository;

        public SignInService(ISignInRepository signInRepository)
        {
            _signInRepository = signInRepository;
        }

        public SignInModel VerifyToken(string token)
        {
            var signIn = _signInRepository.GetByToken(token);
            return Mapper.Map<SignInModel>(signIn);
        }
    }
}
