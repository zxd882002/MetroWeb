﻿using System;
using System.Runtime.Serialization;

namespace MetroWebWcfService
{
    [DataContract]
    public class StationLineInfo
    {
        [DataMember]
        public LineInfo LineInfo { get; set; }

        [DataMember]
        public StartEndTime StartEndTime { get; set; }
    }
}