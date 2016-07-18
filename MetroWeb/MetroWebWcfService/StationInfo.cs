using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

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
    }

    [DataContract]
    public class StationGraph
    {
        [DataMember]
        public int x { get; set; }

        [DataMember]
        public int y { get; set; }
    }

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