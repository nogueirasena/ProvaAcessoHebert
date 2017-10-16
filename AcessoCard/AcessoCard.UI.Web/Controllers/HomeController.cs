using AcessoCard.Application.Dto;
using AcessoCard.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AcessoCard.UI.Web.Controllers
{
    public class HomeController : Controller
    {
      
        private readonly ITwitterAuthenticationAppService _authenticationAppService;
        private readonly ISearchAppService _searchAppService;
        public HomeController(ITwitterAuthenticationAppService authenticationAppService,
                              ISearchAppService searchAppService)
        {
            _authenticationAppService = authenticationAppService;
            _searchAppService = searchAppService;
        }
       
        public ActionResult Index()
        {
            return View();
        }

      
        public ActionResult Busca(string TextoBusca)
        {
            TwitterAuthenticationDto auth = _authenticationAppService.GetAuthentication();
            var List = _searchAppService.GetTextFromHashTag(TextoBusca, auth.token_type, auth.access_token);
            ViewBag.Twites = List;
           

            if (!List.Any())
            {
                ViewBag.error = "Essa HashTag não existe, por favor tentar outra";
                return View();
            }


           
            TempData[TextoBusca] = TextoBusca;

            if (TempData.Values.Count > 20)
            {
                TempData.Remove(TempData.Values.FirstOrDefault().ToString());
            }

            return View();
        }
    }
}