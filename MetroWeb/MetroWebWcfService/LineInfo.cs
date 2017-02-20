using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MetroWebWcfService
{
    [DataContract]
    public class LineInfo
    {
        [DataMember]
        public LineGraph LineGraph { get; set; }
    }

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