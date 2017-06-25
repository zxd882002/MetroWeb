using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    [DataContract]
    public class LineInfo
    {
        [DataMember]
        public string LineId { get; set; }

        [DataMember]
        public LineRoute LineRoute { get; set; }

        [DataMember]
        public string LineColor { get; set; }

        [DataMember]
        public LineGraph LineGraph { get; set; }
    }
}