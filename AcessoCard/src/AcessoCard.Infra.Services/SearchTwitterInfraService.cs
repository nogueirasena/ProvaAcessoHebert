using AcessoCard.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoCard.Domain.Entities;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace AcessoCard.Infra.Services
{
    public class SearchTwitterInfraService : ISearchTwitterRepository
    {
        public List<TwittCard> GetTextFromHashTag(string Hashtag, string type, string token)
        {
            List<TwittCard> twetts = new List<TwittCard>();

            var timelineFormat = String.Format("{0}{1}{2}", "https://api.twitter.com/1.1/search/tweets.json?q=%23", Hashtag , "&count=16&result_type=recent");
            var timelineUrl = string.Format(timelineFormat, "aScreenName");
            HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(timelineUrl);
            var timelineHeaderFormat = "{0} {1}";
            timeLineRequest.Headers.Add("Authorization", string.Format(timelineHeaderFormat, type, token));
            timeLineRequest.Method = "Get";
            try
            {
                WebResponse timeLineResponse = timeLineRequest.GetResponse();
                using (timeLineResponse)
                {
                    using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                    {
                        var timeLineJson = reader.ReadToEnd();



                        var auth = JsonConvert.DeserializeObject<dynamic>(timeLineJson);

                        foreach (var s in auth["statuses"])
                        {
                            twetts.Add(new TwittCard
                                           {
                                               IdTwitt = s["id"].Value,
                                               ProfileDescription = s["user"]["description"].Value,
                                               ProfileImage = s["user"]["profile_image_url"].Value,
                                               UserName = s["user"]["name"].Value,
                                               Text = s["text"].Value
                                           });


                        }


                    }
                }
            }
            catch (Exception e)
            {
                return new List<TwittCard>();
            }
           
            return twetts;
        }
    }
}
