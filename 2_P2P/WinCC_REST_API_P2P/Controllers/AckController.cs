using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AddressSpace;
using OpcLabs.EasyOpc.UA.OperationModel;
using Serilog;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WinCC_REST_API.Global;
using WinCC_REST_API_P2P.Models;

namespace WinCC_REST_API_P2P.Controllers
{
    public class AckController : ApiController
    {
        public HttpResponseMessage Post([FromBody] Ack ack)
        {
            UAEndpointDescriptor endpointDescriptor = Init._endpoint;
            UANodeId nodeId = null;
            byte[] eventId = null;

            if (!ModelState.IsValid)
            {
                Log.Error("api/ack: Ungültige Daten übermittelt bekommen!");
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid Model");
            }
            else
            {
                if (ack.ConditionName == null)
                {
                    Log.Error("api/ack: Keine Id erhalten");
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid data (ID)");
                }
                Log.Information("Quittierung aufgerufen mit Nummer: " + ack.ConditionName);
                Alarm alarmlist;
                if (Init._alarms.TryGetValue(ack.ConditionName, out alarmlist))
                {
                    try
                    {
                        Init._alarmsAndConditionsClient.Acknowledge(
                            endpointDescriptor,
                            nodeId = new UANodeId("nsu=http://opcfoundation.org/UA/;i=2881"),
                            eventId = System.Text.Encoding.Unicode.GetBytes(alarmlist.EventId.ToString()),
                            "OPCUA");
                        Log.Information("Alarm mit Nummer <" + ack.ConditionName + "> erfolgreich quittiert");
                        return Request.CreateResponse(HttpStatusCode.OK, "Alarm mit Nummer <" + ack.ConditionName + "> erfolgreich quittiert");
                    }
                    catch (UAException uaException)
                    {
                        Log.Error(uaException.InnerException + " (Kein Alarm mit dieser ID anstehend)");
                        return Request.CreateResponse(HttpStatusCode.Conflict, uaException.InnerException + "; Kein Alarm mit Nummer <" + ack.ConditionName + "> anstehend");
                    }
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Conflict, " Kein Alarm mit Nummer <" + ack.ConditionName + "> anstehend");
                }



            }
        }
    }
}
