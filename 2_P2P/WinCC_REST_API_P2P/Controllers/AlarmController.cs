using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinCC_REST_API.Global;
using WinCC_REST_API_P2P.Models;

namespace WinCC_REST_API_P2P.Controllers
{
    public class AlarmController : ApiController
    {
        //Endpointadresse: http://localhost/api/alarm (GET)
        public HttpResponseMessage Get()
        {
            if (Init._stateIO == false)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Verbindung zu OPC UA Alarms & Conditions Server nicht hergestellt");
            }
            else
            {
                try
                {
                    return Request.CreateResponse<IEnumerable<Alarm>>(HttpStatusCode.OK, Init._alarms.Values);
                }
                catch (Exception ex)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
                }
            }

        }
    }
}