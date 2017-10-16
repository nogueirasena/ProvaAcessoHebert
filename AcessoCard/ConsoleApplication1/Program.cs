using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {


          
            var timelineFormat = "https://api.twitter.com/1.1/search/tweets.json?q=%23" + "hebert" + "&count=16&result_type=recent";
            var timelineUrl = string.Format(timelineFormat, "aScreenName");
            HttpWebRequest timeLineRequest = (HttpWebRequest)WebRequest.Create(timelineUrl);
            var timelineHeaderFormat = "{0} {1}";
            timeLineRequest.Headers.Add("Authorization", string.Format(timelineHeaderFormat, "bearer", "AAAAAAAAAAAAAAAAAAAAAMPU2gAAAAAAz4L9UijyYPXItZGvkB32IQlLdPA%3DpTeWs2imybGIQ1lLGG4pOwwwg9MR63NNeyMnYvrC5L2ugXLH7T"));
            timeLineRequest.Method = "Get";

            WebResponse timeLineResponse = timeLineRequest.GetResponse();
            using (timeLineResponse)
            {
                using (var reader = new StreamReader(timeLineResponse.GetResponseStream()))
                {
                    var timeLineJson = reader.ReadToEnd();

                   

                   var auth = JsonConvert.DeserializeObject<dynamic>(timeLineJson);

                    foreach(var s in auth["statuses"])
                    {
                        Console.WriteLine(s["user"]["name"].Value);
                        Console.WriteLine(s["user"]["profile_image_url"].Value);
                        Console.WriteLine(s["user"]["description"].Value);
                        Console.WriteLine(s["id"].Value);
                        Console.WriteLine(s["text"].Value);


                    }
                    
                   
                }
            }
            Console.ReadLine();

        }
    }
}
