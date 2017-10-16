using AcessoCard.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.Application.Dto;
using AcessoCard.Domain.Interfaces.Services;
using AcessoCard.Domain.Common;
using AutoMapper;

namespace AcessoCard.Application
{
    public class TwitterAuthenticationAppService : ITwitterAuthenticationAppService
    {
      
        private readonly ITwitterAuthenticationService _authenticationService;

        public TwitterAuthenticationAppService(ITwitterAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public TwitterAuthenticationDto GetAuthentication()
        {
           var authenticationDomain = _authenticationService.GetAuthentication();

            var retorno = Mapper.Map<TwitterAuthentication, TwitterAuthenticationDto>(authenticationDomain);

            return retorno;
        }
    }
}
