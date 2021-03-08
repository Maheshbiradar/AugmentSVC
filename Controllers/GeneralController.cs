using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using WinnovarService.HelperClasses;

namespace WinnovarService.Controllers
{
    public class GeneralController : ApiController
    {
        [HttpGet]
        [Route("api/General/GetType/{textInput}/")]
        public String GetType(string textInput)
        {
            using (var client = new WebClient())
            {
                RootObject response = MakeRequest(textInput);

                return response.topScoringIntent.intent;

            }
        }


        static RootObject MakeRequest(string textInput)
        {
            var client = new WebClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.Headers.Add("Ocp-Apim-Subscription-Key", "<key>");

            // Request parameters
            queryString["timezoneOffset"] = "0";
            queryString["verbose"] = "true";
            queryString["spellCheck"] = "true";
            queryString["bing-spell-check-subscription-key"] = "<key>";
            queryString["log"] = "{boolean}";
            var uri = "https://westus.api.cognitive.microsoft.com/luis/v2.0/apps/94043d35-5d64-4d07-9a28-deca23aedcf0?q=" + textInput + "&" + queryString;

            var response = JsonConvert.DeserializeObject<RootObject>(client.DownloadString(uri));
            return response;
        }

    }
}
