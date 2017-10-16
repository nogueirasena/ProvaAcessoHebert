using AcessoCard.Domain.Common;

namespace AcessoCard.Domain.Interfaces.Services
{
    public interface ITwitterAuthenticationService
    {
        TwitterAuthentication GetAuthentication();
    }
}
