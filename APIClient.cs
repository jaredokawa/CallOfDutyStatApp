using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CODStatApp
{
    public class ApiClient
    {

        //public static RestResponse CallofDuty()
        //{
        //    var client = new RestClient("https://call-of-duty-modern-warfare.p.rapidapi.com/warzone/Amartin743/psn");
        //    var request = new RestRequest();
        //    request.AddHeader("X-RapidAPI-Key", "b17cfa5011msh21bce056a67fd60p189f9cjsn18606d18a038");
        //    request.AddHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");
        //    RestResponse response = client.Execute(request);

        //    return response;
        //}

        //public static Gamer BRCoDParse(RestResponse response)
        //{
        //    var brObj = JObject.Parse(response.Content).GetValue("data");

        //    var gamerWins = brObj["lifetime"]["mode"]["br"]["properties"]["wins"];
        //    var gamerkills = brObj["lifetime"]["mode"]["br"]["properties"]["kills"];
        //    var gamerkdRatio = brObj["lifetime"]["mode"]["br"]["properties"]["kdRatio"];
        //    var gamertopTwentyFive = brObj["lifetime"]["mode"]["br"]["properties"]["topTwentyFive"];
        //    var gamerobjTime = brObj["lifetime"]["mode"]["br"]["properties"]["objTime"];
        //    var gamertopTen = brObj["lifetime"]["mode"]["br"]["properties"]["topTen"];
        //    var gamerrevives = brObj["lifetime"]["mode"]["br"]["properties"]["revives"];
        //    var gamertopFive = brObj["lifetime"]["mode"]["br"]["properties"]["topFive"];
        //    var gamerscore = brObj["lifetime"]["mode"]["br"]["properties"]["score"];
        //    var gamerscorePerMinute = brObj["lifetime"]["mode"]["br"]["properties"]["scorePerMinute"];
        //    var gamerdeaths = brObj["lifetime"]["mode"]["br"]["properties"]["deaths"];

        //    var gamer = new Gamer()
        //    {
        //        wins = (double)gamerWins,
        //        kills = (double)gamerkills,
        //        kdRatio = (double)gamerkdRatio,
        //        topTwentyFive = (double)gamertopTwentyFive,
        //        objTime = (double)gamerobjTime,
        //        topTen = (double)gamertopTen,
        //        revives = (double)gamerrevives,
        //        topFive = (double)gamertopFive,
        //        score = (double)gamerscore,
        //        scorePerMinute = (double)gamerscorePerMinute,
        //        deaths = (double)gamerdeaths,
        //    };

        //    return gamer;
        //}

        private const string BaseUrl = "https://call-of-duty-modern-warfare.p.rapidapi.com";
        private const string ApiKey = "b17cfa5011msh21bce056a67fd60p189f9cjsn18606d18a038";

        private static RestClient client;

        static ApiClient()
        {
            client = new RestClient(BaseUrl);
            client.AddDefaultHeader("X-RapidAPI-Key", ApiKey);
            client.AddDefaultHeader("X-RapidAPI-Host", "call-of-duty-modern-warfare.p.rapidapi.com");
        }

        public static RestResponse CallOfDuty(string platform, string username)
        {
            var request = new RestRequest($"warzone/{username}/{platform}");
            var response = client.Execute(request);

            return response;
        }

        public static Gamer ParseResponse(RestResponse response)
        {
            var brObj = JObject.Parse(response.Content).GetValue("data");

            var gamerStats = brObj["lifetime"]["mode"]["br"]["properties"];

            var gamer = new Gamer()
            {
                wins = (double)gamerStats["wins"],
                kills = (double)gamerStats["kills"],
                kdRatio = (double)gamerStats["kdRatio"],
                topTwentyFive = (double)gamerStats["topTwentyFive"],
                objTime = (double)gamerStats["objTime"],
                topTen = (double)gamerStats["topTen"],
                revives = (double)gamerStats["revives"],
                topFive = (double)gamerStats["topFive"],
                score = (double)gamerStats["score"],
                scorePerMinute = (double)gamerStats["scorePerMinute"],
                deaths = (double)gamerStats["deaths"]
            };

            return gamer;
        }
    }
}
