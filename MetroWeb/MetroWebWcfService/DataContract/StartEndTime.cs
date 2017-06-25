using System;
using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    [DataContract]
    public class StartEndTime
    {
        [DataMember]
        public string StartTime { get; set; }

        [DataMember]
        public string EndTime { get; set; }
    }
}