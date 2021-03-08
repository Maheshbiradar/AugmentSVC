using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinnovarService.Models;

namespace WinnovarService.Controllers
{
    public class PropertiesController : ApiController
    {
        [HttpGet]        
        public List<Property> GetProperties()
        {
            WinnovarEntities a = new WinnovarEntities();
            return a.Properties.ToList();
        }
    }
}