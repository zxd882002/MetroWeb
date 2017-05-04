using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    [DataContract]
    public class LineInfo
    {
        [DataMember]
        public LineGraph LineGraph { get; set; }
    }
}