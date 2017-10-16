using AcessoCard.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoCard.Application.Interfaces
{
    public interface ITwitterAuthenticationAppService
    {
        TwitterAuthenticationDto GetAuthentication();
    }
}
