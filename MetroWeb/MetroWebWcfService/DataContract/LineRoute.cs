using System.Runtime.Serialization;
namespace MetroWebWcfService
{
    [DataContract]
    public class LineRoute
    {
        [DataMember] public string FromStationName { get; set; }
        [DataMember] public string ToStationName { get; set; }
    }
}