using AcessoCard.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoCard.Domain.Interfaces.Services
{
    public interface ISearchTwitterService
    {
        List<TwittCard> GetTextFromHashTag(string Hashtag, string type, string token);
    }
}
