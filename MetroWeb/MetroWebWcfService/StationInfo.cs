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
        public string StationName { get; set; }
    }
}