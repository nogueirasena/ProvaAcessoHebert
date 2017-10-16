using AcessoCard.Domain.Entities;
using System.Collections.Generic;

namespace AcessoCard.Domain.Interfaces.Repository
{
    public interface ISearchTwitterRepository
    {
        List<TwittCard> GetTextFromHashTag(string Hashtag, string type, string token);
    }
}
