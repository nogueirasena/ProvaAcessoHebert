using AcessoCard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.Domain.Common;
using AcessoCard.Domain.Interfaces.Repository;

namespace AcessoCard.Domain.Service
{
    public class TwitterAuthenticationService : ITwitterAuthenticationService
    {
        private readonly ITwitterAuthentication _authenticationRepository;

        public TwitterAuthenticationService(ITwitterAuthentication authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }
        public TwitterAuthentication GetAuthentication()
        {
            return _authenticationRepository.GetAuthentication();
        }
    }
}
