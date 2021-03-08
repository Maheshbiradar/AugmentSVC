using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinnovarService.HelperClasses;

namespace WinnovarService.Controllers
{
    public class HospitalController : ApiController
    {
        [HttpGet]        
        public PlacesApiQueryResponse GetHospitals(double lat, double lon)
        {
            using (var client = new WebClient())
            {
                var response = client.DownloadString(string.Format("https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={0},{1}&radius=500&type=hospital&key=<key>", lat, lon));
                return JsonConvert.DeserializeObject<PlacesApiQueryResponse>(response);
            }
        }

    }
}