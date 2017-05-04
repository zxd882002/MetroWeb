using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    [DataContract]
    public class StationInfo
    {
        [DataMember]
        public int StationId { get; set; }

        [DataMember]
        public StationGraph StationGraph { get; set; }

        [DataMember]
        public NameGraph NameGraph { get; set; }

        [DataMember]
        public string StationName { get; set; }

        [DataMember]
        public StationLineInfo[] StationLines { get; set; }
    }
}