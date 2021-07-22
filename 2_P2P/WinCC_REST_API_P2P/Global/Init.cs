using OpcLabs.BaseLib.ComponentModel;
using OpcLabs.EasyOpc.UA;
using OpcLabs.EasyOpc.UA.AlarmsAndConditions;
using Serilog;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Reflection;
using WinCC_REST_API_P2P.Models;

namespace WinCC_REST_API.Global
{
    public class Init
    {
        public static readonly EasyUAClient _client = new EasyUAClient();
        public static readonly IEasyUAAlarmsAndConditionsClient _alarmsAndConditionsClient = Init._client.AsAlarmsAndConditionsClient();
        public static Dictionary<string, Alarm> _alarms = new Dictionary<string, Alarm>();
        public static string _endpoint { get; set; }
        public static string _deployedIP { get; set; }
        public static bool _stateIO;



        public void Initialize()
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(@"C:\Log\logging.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("Logging initialized");

            if (ConfigurationManager.AppSettings["deployedIP"] != null)
            {
                Init._deployedIP = ConfigurationManager.AppSettings["deployedIP"];
                Debug.WriteLine("deployedIP: {0}", Init._deployedIP);
            }
            else
            {
                Debug.WriteLine("deployedIP not valid");
            }
            if (ConfigurationManager.AppSettings["endpointDescriptor"] != null)
            {
                Init._endpoint = ConfigurationManager.AppSettings["endpointDescriptor"];
                Debug.WriteLine("Endpoint: {0}", Init._endpoint);
            }
            else
            {
                Debug.WriteLine("Endpoint not valid");
            }
        }
    }
}