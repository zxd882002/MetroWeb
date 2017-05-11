using System;
using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    public class StationLineInfo
    {
        [DataMember]
        public LineInfo LineInfo { get; set; }

        [DataMember]
        public string StartEndTime { get; set; }
    }
}