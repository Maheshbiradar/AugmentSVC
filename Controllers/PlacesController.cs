using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinnovarService.Models;

namespace WinnovarService.Controllers
{
    public class PlacesController : ApiController
    {
        [HttpGet]
        public List<Place> GetPlaces()
        {
            WinnovarEntities a = new WinnovarEntities();
            return a.Places.ToList();
        }
    }
}