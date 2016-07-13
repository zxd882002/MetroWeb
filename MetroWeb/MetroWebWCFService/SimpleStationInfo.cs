using System.Runtime.Serialization;

namespace MetroWebWCFService
{
    [DataContract]
    public class SimpleStationInfo
    {
        [DataMember]
        public string StationName { get; set; }

        [DataMember]
        public string[] Lines { get; set; }
    }
}
