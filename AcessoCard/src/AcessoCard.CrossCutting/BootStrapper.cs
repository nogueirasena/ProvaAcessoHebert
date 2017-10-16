using AcessoCard.Application;
using AcessoCard.Application.Interfaces;
using AcessoCard.Domain.Interfaces.Repository;
using AcessoCard.Domain.Interfaces.Services;
using AcessoCard.Domain.Service;
using AcessoCard.Infra.Services;
using SimpleInjector;

namespace AcessoCard.CrossCutting
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            container.RegisterSingleton<ITwitterAuthenticationAppService, TwitterAuthenticationAppService>();
            container.RegisterSingleton<ITwitterAuthenticationService, TwitterAuthenticationService>();
            container.RegisterSingleton<ITwitterAuthentication, AuthenticationService>();

            container.RegisterSingleton<ISearchAppService, SearchAppService>();
            container.RegisterSingleton<ISearchTwitterRepository, SearchTwitterInfraService>();
            container.RegisterSingleton<ISearchTwitterService, SearchTwitterService>();


        }
    }
}
