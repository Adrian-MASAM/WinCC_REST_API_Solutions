using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Remote_REST_API_P2P.Models
{
    public class Alarm //ns=2i=1
    {
        public string AGNR { get; set; }
        public string ALARMCOUNT { get; set; }
        public string APPLICATION { get; set; }
        public string AckedState { get; set; }
        public string ActiveState { get; set; }
        public string BACKCOLOR { get; set; }
        public string BIG_COUNTER { get; set; }
        public string BLOCKINFO { get; set; }
        //public string BranchId { get; set; } //vom OPC UA-Server nicht unterstützt Systemhandbuch, 02/2017, A5E40840067-AA S.210
        public string CLASSID { get; set; }
        public string CLASSNAME { get; set; }
        public string COMMENT { get; set; }
        public string COMPUTER { get; set; }
        public string COUNTER { get; set; }
        public string CPUNR { get; set; }
        public string ClientUserId { get; set; }
        public string Comment { get; set; }
        public string ConditionClassId { get; set; }
        public string ConditionClassName { get; set; }
        public string ConditionName { get; set; }
        //public string ConfirmedState { get; set; } //vom OPC UA-Server nicht unterstützt Systemhandbuch, 02/2017, A5E40840067-AA S.210
        public string DURATION { get; set; }
        public string EnabledState { get; set; }
        public string EventId { get; set; }
        public string EventType { get; set; }
        public string FLAGS { get; set; }
        public string FLASHCOLOR { get; set; }
        public string FORECOLOR { get; set; }
        public string HIDDEN_COUNT { get; set; }
        public string INFOTEXT { get; set; }
        //public string InputNode { get; set; } //vom OPC UA-Server nicht unterstützt Systemhandbuch, 02/2017, A5E40840067-AA S.210
        public string LOCKCOUNT { get; set; }
        public string LOOPINALARM { get; set; }
        //public string LastSeverity { get; set; } //vom OPC UA-Server nicht unterstützt Systemhandbuch, 02/2017, A5E40840067-AA S.210
        public string LocalTime { get; set; }
        public string MODIFYSTATE { get; set; }
        //public string MaxTimeShelved { get; set; } //vom OPC UA-Server nicht unterstützt Systemhandbuch, 02/2017, A5E40840067-AA S.210
        public string Message { get; set; }
        public string OS_EVENTID { get; set; }
        public string OS_HIDDEN { get; set; }
        public string PARAMETER { get; set; }
        public string Priority { get; set; }
        public string PROCESSVALUE01 { get; set; }
        public string PROCESSVALUE02 { get; set; }
        public string PROCESSVALUE03 { get; set; }
        public string PROCESSVALUE04 { get; set; }
        public string PROCESSVALUE05 { get; set; }
        public string PROCESSVALUE06 { get; set; }
        public string PROCESSVALUE07 { get; set; }
        public string PROCESSVALUE08 { get; set; }
        public string PROCESSVALUE09 { get; set; }
        public string PROCESSVALUE10 { get; set; }
        public string QUITCOUNT { get; set; }
        public string QUITSTATETEXT { get; set; }
        public string Quality { get; set; }
        public string ReceiveTime { get; set; }
        public string Retain { get; set; }
        public string State { get; set; } //Hilfselement (nicht aus OPC UA)
        public string STATETEXT { get; set; }
        public string Severity { get; set; }
        public string SourceName { get; set; }
        public string SourceNode { get; set; }
        //public string SuppressedOrShelved { get; set; } //vom OPC UA-Server nicht unterstützt Systemhandbuch, 02/2017, A5E40840067-AA S.210
        //public string SuppressedState { get; set; } //vom OPC UA-Server nicht unterstützt Systemhandbuch, 02/2017, A5E40840067-AA S.210
        public string TEXT01 { get; set; }
        public string TEXT02 { get; set; }
        public string TEXT03 { get; set; }
        public string TEXT04 { get; set; }
        public string TEXT05 { get; set; }
        public string TEXT06 { get; set; }
        public string TEXT07 { get; set; }
        public string TEXT08 { get; set; }
        public string TEXT09 { get; set; }
        public string TEXT10 { get; set; }
        public string TYPEID { get; set; }
        public string TYPENAME { get; set; }
        public string Time { get; set; }
        public string USER { get; set; }
    }
}