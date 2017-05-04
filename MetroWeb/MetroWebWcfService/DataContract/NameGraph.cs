using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    [DataContract]
    public class NameGraph
    {
        [DataMember]
        public int x { get; set; }

        [DataMember]
        public int y { get; set; }

        [DataMember]
        public string text { get; set; }
    }
}