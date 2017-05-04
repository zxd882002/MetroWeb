using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    [DataContract]
    public class LineGraph
    {
        [DataMember]
        public string strokeStyle { get; set; }

        [DataMember]
        public string p1 { get; set; }

        [DataMember]
        public string p2 { get; set; }
    }
}