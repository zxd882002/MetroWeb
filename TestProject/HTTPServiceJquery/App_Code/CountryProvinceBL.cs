using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Runtime.Serialization;
using System.Collections.Specialized;

/// <summary>
/// Summary description for CountryProvinceBL
/// </summary>
public class CountryProvinceBL
{
    NameValueCollection nvProvince = null;
    public CountryProvinceBL()
    {
        nvProvince = new NameValueCollection();
        nvProvince.Add("usa", "Massachusetts");
        nvProvince.Add("usa", "California");
        nvProvince.Add("usa", "Texas");
        nvProvince.Add("usa", "New York");
        nvProvince.Add("usa", "Illinois");
        nvProvince.Add("usa", "Washington");
        nvProvince.Add("india", "Tamil Nadu");
        nvProvince.Add("india", "Karnataka");
        nvProvince.Add("india", "Andhra Pradesh?");
        nvProvince.Add("india", "Kerala");        
    }
    
    public string[] GetProvince(string Country)
    {
        return nvProvince.GetValues(Country).ToArray();
    }


}

[DataContract]
public class CustomData
{
    [DataMember]
    public String BrowserInfo;
    [DataMember]
    public String[] ProvinceInfo;
}
