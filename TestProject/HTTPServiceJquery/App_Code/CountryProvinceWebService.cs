using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for CountryProvince
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// Below line allows the web service to be called through HTTP protocol. 
[System.Web.Script.Services.ScriptService]
public class CountryProvinceWebService : System.Web.Services.WebService
{

    [WebMethod]
    public string[] GetProvince(string Country) {
        return new CountryProvinceBL().GetProvince(Country);
    }
    
}

