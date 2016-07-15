<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="JQueryPage.aspx.cs" Inherits="_JQueryPage" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" language="javascript" src="script/jquery-1.3.2.min.js"></script>
    <script type="text/javascript" >

        var varType;
        var varUrl;
        var varData;
        var varContentType;
        var varDataType;
        var varProcessData;          
        //Generic function to call AXMX/WCF  Service        
        function CallService() 
        {
                $.ajax({
                    type        : varType, //GET or POST or PUT or DELETE verb
                    url         : varUrl, // Location of the service
                    data        : varData, //Data sent to server
                    contentType : varContentType, // content type sent to server
                    dataType    : varDataType, //Expected data format from server
                    processdata : varProcessData, //True or False
                    success     : function(msg) {//On Successfull service call
                    ServiceSucceeded(msg);                    
                    },
                    error: ServiceFailed// When Service call fails
                });
        }

        function ServiceSucceeded(result) {//When service call is sucessful
            var ProvinceDDL = document.getElementById("ddlProvince");
            for (j = ProvinceDDL.options.length - 1; j >= 0; j--) { ProvinceDDL.remove(j); }
            var resultObject = null;
            if (varDataType == "json")
            {
                if (varUrl.indexOf(".asmx/") > 0) {
                 resultObject = result.d; // Constructed object name will be object.d //Button 1
                }
                else if (varType == "GET") {resultObject = result;}
                else {
                    // Constructed object name will be object.[ServiceName]Result // Button 2 & 3
                    resultObject = result.GetProvinceResult;
                    if (resultObject == null) {
                        //WCF Service with multiple output paramaetrs //Button 4
                        resultObject = result.GetProvinceAndBrowserResult.ProvinceInfo;
                    }

                }

                 for (i = 0; i < resultObject.length; i++) {
                     var opt = document.createElement("option"); opt.text = resultObject[i];
                     ProvinceDDL.options.add(opt)
                 }

                 if (result.GetProvinceAndBrowserResult != null) 
                    { //WCF Service with multiple output paramaetrs //Button 4
                     $("#divMulti").html(result.GetProvinceAndBrowserResult.BrowserInfo);
                     }
                 else
                     $("#divMulti").html("click button 4");
                
                 
             }
             else if (varDataType == "xml") {//Parse XML based result;
                $(result).find("GetProvinceXMLResult").children().each(function() {
                var opt = document.createElement("option"); opt.text = $(this).text();
                ProvinceDDL.options.add(opt)        
                });
            }
           
             varType=null;varUrl = null;varData = null;varContentType = null;varDataType = null;varProcessData = null;     
        }
        function ServiceFailed(result) {
            alert('Service call failed: ' + result.status + '' + result.statusText);
            varType = null; varUrl = null; varData = null; varContentType = null; varDataType = null; varProcessData = null;     
        }

        function CountryProvinceWebService() {
            varType = "POST";
            varUrl = "service/CountryProvinceWebService.asmx/GetProvince";
            varData = '{"Country": "' + $('#ddlCountry').val() + '"}';
            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varProcessData = true;
            CallService();
        }
        
        function CountryProvinceWCFJSON() {
            varType = "POST";
            varUrl = "service/CountryProvinceWCFService.svc/GetProvince";
            varData = '{"Country": "' + $('#ddlCountry').val() + '"}';
            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varProcessData = true;
            CallService();
        }

        function CountryProvinceWCFXML() {
            varType = "POST";
            varUrl = "service/CountryProvinceWCFService.svc/GetProvinceXML";
            varData = '{"Country": "' + $('#ddlCountry').val() + '"}';
            varContentType = "application/json; charset=utf-8"; 
            varDataType = "xml"; 
            varProcessData = true;
            CallService();
        }

        function CountryProvinceWCFJSONMulti() {
            var browser = "";
            if (jQuery.browser.mozilla == true) browser="firefox"
            else if(jQuery.browser.msie == true) browser = "ie"

            varType = "POST";
            varUrl = "service/CountryProvinceWCFService.svc/GetProvinceAndBrowser";
            //We are passing multiple paramers to the service in json format {"Country" : "india", "Browser":"ie"}
            varData = '{"Country": "' + $('#ddlCountry').val() + '","Browser": "' + browser + '"}';
            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varProcessData = true;
            CallService();
        }

        function CountryProvinceWCFJSONGet() {
            varType = "GET";
            varUrl = "service/CountryProvinceWCFService.svc/GetProvinceGET?Country=" +$('#ddlCountry').val();
            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varProcessData = false;
            CallService();
        }


        function CountryProvinceWCFREST() {
            varType = "GET";
            varUrl = "service/CountryProvinceWCFService.svc/GetProvinceREST/" + $('#ddlCountry').val();            
            varContentType = "application/json; charset=utf-8";
            varDataType = "json";
            varProcessData = false;
            CallService();
        }


        function ShowImage() {
            // WCF service is used to stream the image. Service url is assigned to src attribute of the image
            // Basically a GET request
            $("#image1").attr('src','service/CountryProvinceWCFService.svc/GetPicture');
            
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">    
    <div><b>
    <p>JQuery , WCF , JSON , XML , AJAX , ASMX , REST</p><br />
    </b>
    
        <div>
        
            <div style="background-color:ButtonShadow;width:500px;">
            <hr /><br />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Country: &nbsp;
            
            <select id="ddlCountry">                   
                    <option id='usa'>USA</option>
                    <option value='india'>India</option>
             </select>
            

            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            Provinces:&nbsp;             
              <select id="ddlProvince" name="ddlProvince">
               </select><br />
               <center><div id="divMulti" style="color:White">&nbsp;</div></center>
                <br /><br />
            </div>              
        </div>
<div>
<table><tr><td valign="top">
        <table border="1" width="500px" height="400px" cellpadding="5" cellspacing="5" 
            style="background-color: #F0F0F0">
            <tr>
                    <td align="left">1) Call ASMX Web service using JQuery </td>
                    <td><input type="button" value="Invoke" id="btnInvokeWebService" onclick="CountryProvinceWebService();" /> </td>
            </tr>
            <tr>
                    <td align="left">2) Call WCF service using JQuery and get data in JSON Format </td>
                    <td><input type="button" value="Invoke" id="btnInvokeWCFJSON" onclick="CountryProvinceWCFJSON();" /> </td>
            </tr>     
            <tr>
                    <td align="left">3) Call WCF service using JQuery and get data in XML Format </td>
                    <td><input type="button" value="Invoke" id="btnInvokeWCFXML" onclick="CountryProvinceWCFXML();" /> </td>
            </tr>
            <tr>
                    <td align="left">4)  Call WCF service using JQuery and get data in JSON Format (pass multiple input parameters) & ( Get multiple objects as output using DataContract)</td>
                    <td><input type="button" value="Invoke" id="btnInvokeWCFMJSONMultiple" onclick="CountryProvinceWCFJSONMulti();" /> </td>
            </tr> 
            <tr>
                    <td align="left">5) Call WCF service using JQuery[ Get Method] and get data in JSON Format</td>
                    <td><input type="button" value="Invoke" id="Button1" onclick="CountryProvinceWCFJSONGet();" /> </td>
            </tr>             
            <tr>
                    <td align="left">6) Call REST based WCF service using JQuery</td>
                     <td><input type="button" value="Invoke" id="Button2" onclick="CountryProvinceWCFREST();" /> </td>
            </tr>      
            <tr>
                    <td align="left">7) Stream an image through WCF and display it in browser</td>
                     <td><input type="button" value="Invoke" id="Button3" onclick="ShowImage();" /> </td>
            </tr>                                                                   
        </table>
        
        </td>
        <td>
        <img src="" id="image1" width="500" height="400" visible="false"  />
        </td>
        
        </tr></table>
             <br />  <br />  
             <hr />   
             <br />           
</div>
    </div>
    
    - sridhar subramanian
    </form>
</body>
</html>
