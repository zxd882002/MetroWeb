using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.ServiceModel.Activation;
using System.IO;
using System.Web.Hosting;


public class CountryProvinceWCFService : ICountryProvinceWCFService
{
   
    public string[] GetProvince(string Country)
    {
        return new CountryProvinceBL().GetProvince(Country);
    }

    public string[] GetProvinceXML(string Country)
    {
        return new CountryProvinceBL().GetProvince(Country);
    }



    public CustomData GetProvinceAndBrowser(string Country, string Browser)
    {
        CustomData customData = new CustomData();
        customData.ProvinceInfo = new CountryProvinceBL().GetProvince(Country);
        if (Browser == "ie")
            customData.BrowserInfo = " Did you learn to program IE 8.0";
        else if (Browser == "firefox")
            customData.BrowserInfo = " Mozilla rocks, try Firebug & Fiddler addon's";
        else
            customData.BrowserInfo = " I did not test in this browser";
        return customData;
    }

    public string[] GetProvinceGET(string Country)
    {
        return new CountryProvinceBL().GetProvince(Country);
    }

    public string[] GetProvinceREST(string Country)
    {
        return new CountryProvinceBL().GetProvince(Country);
    }


    public Stream GetPicture()
    {
        string fileName = Path.Combine(HostingEnvironment.ApplicationPhysicalPath,"vista.jpg");
        FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
        System.ServiceModel.Web.WebOperationContext.Current.OutgoingResponse.ContentType = "image/jpeg";
        return (Stream)fileStream;
    }
}
