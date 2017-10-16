using AcessoCard.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.Domain.Entities;
using AcessoCard.Domain.Interfaces.Repository;

namespace AcessoCard.Domain.Service
{
    public class SearchTwitterService : ISearchTwitterService
    {
        private readonly ISearchTwitterRepository _searchTwitter;
        public SearchTwitterService(ISearchTwitterRepository searchTwitter)
        {
            _searchTwitter = searchTwitter;

        }
        public List<TwittCard> GetTextFromHashTag(string Hashtag, string type, string token)
        {
            return  _searchTwitter.GetTextFromHashTag(Hashtag, type, token);
        }
    }
}
