using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    [DataContract]
    public class StationGraph
    {
        [DataMember]
        public int x { get; set; }

        [DataMember]
        public int y { get; set; }
    }
}