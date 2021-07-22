using Newtonsoft.Json;
using Remote_REST_API_P2P.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Remote_REST_API_P2P.Controllers
{
    public class AlarmController : ApiController
    {
        // POST api/values
        public void Post([FromBody] Alarm alarm)
        {
            Log.Information("Übermittle Werte: \r\n*************************************" + JsonConvert.SerializeObject(alarm));
        }
    }
}
