using AcessoCard.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.Application.Dto;
using AcessoCard.Domain.Interfaces.Services;
using AutoMapper;
using AcessoCard.Domain.Entities;

namespace AcessoCard.Application
{
    public class SearchAppService : ISearchAppService
    {
        public List<SearchDto> GetTextFromHashTag(string Hashtag, string type, string token)
        {
            var SearchDomain = _searchService.GetTextFromHashTag(Hashtag, type, token);

            var retorno = Mapper.Map<List<TwittCard>, List<SearchDto>>(SearchDomain);

            return retorno;
        }

        private readonly ISearchTwitterService _searchService;
        public SearchAppService(ISearchTwitterService searchService)
        {
            _searchService = searchService;
        }
    }
}
