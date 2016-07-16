using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Text;

namespace MetroWebWcfServiceLibrary
{
     [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MetroWebService : IMetroWebService
    {
        public string GetStationNameByStationId(int stationId)
        {
            return stationId.ToString();
        }
    }
}
