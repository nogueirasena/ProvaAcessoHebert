using System;
using AcessoCard.Domain.Common;
using AcessoCard.Domain.Interfaces.Repository;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace AcessoCard.Infra.Services
{
    public class AuthenticationService : ITwitterAuthentication
    {
        public TwitterAuthentication GetAuthentication()
        {
            TwitterAuthentication auth = new TwitterAuthentication();
            var oAuthConsumerKey = "8Tgj5fGqrAqEm9BxEXcmEi0Ju";
            var oAuthConsumerSecret = "cLCYC6wVmwSjQOgVxLQhxpiX5DQgVgjiIWtz7b5GKt0YaS7XAD";
            var oAuthUrl = "https://api.twitter.com/oauth2/token";
            var authHeaderFormat = "Basic {0}";
            var authHeader = string.Format(authHeaderFormat,
                Convert.ToBase64String(Encoding.UTF8.GetBytes(Uri.EscapeDataString(oAuthConsumerKey) + ":" +
                                                              Uri.EscapeDataString((oAuthConsumerSecret)))));
            var postBody = "grant_type=client_credentials";
            HttpWebRequest authRequest = (HttpWebRequest)WebRequest.Create(oAuthUrl);
            authRequest.Headers.Add("Authorization", authHeader);
            authRequest.Method = "POST";
            authRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
            authRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            using (Stream stream = authRequest.GetRequestStream())
            {
                byte[] content = ASCIIEncoding.ASCII.GetBytes(postBody);
                stream.Write(content, 0, content.Length);
            }
            authRequest.Headers.Add("Accept-Encoding", "gzip");
            WebResponse authResponse = authRequest.GetResponse();
            // TwitAuthenticateResponse twitAuthResponse;
            using (authResponse)
            {
                using (var reader = new StreamReader(authResponse.GetResponseStream()))
                {
                    //JavaScriptSerializer js = new JavaScriptSerializer();
                    auth  = JsonConvert.DeserializeObject<TwitterAuthentication>(reader.ReadToEnd());
                   
                    //twitAuthResponse = JsonConvert.DeserializeObject<TwitAuthenticateResponse>(objectText);
                }
            }
            return auth;
        }
    }
}
