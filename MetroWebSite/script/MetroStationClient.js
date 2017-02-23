function MetroStationClient(ReDraw) 
{
	this.MetroStationArray = null;
	this.MetroStationLineArray = null;
	this.ReDrawFunction = ReDraw;
};

MetroStationClient.prototype.GetMetroStationArray = function() {
	var url = 'http://localhost:8732/MetroWebService.svc/GetStationInfos';
	var successCallback = this.OnGetMetroStationArraySuccess;
	var errorCallback = this.OnError;
    var ajaxHelper = new AjaxHelper(url, this, successCallback, errorCallback);
	ajaxHelper.CallWCFAsync();
};

MetroStationClient.prototype.GetMetroStationLineArray = function(){
	var url = 'http://localhost:8732/MetroWebService.svc/GetLineInfos';
	var successCallback = this.OnGetMetroStationLineArraySuccess;
	var errorCallback = this.OnError;
    var ajaxHelper = new AjaxHelper(url, this, successCallback, errorCallback);
	ajaxHelper.CallWCFAsync();
};

MetroStationClient.prototype.OnGetMetroStationArraySuccess = function(msg){
	this.MetroStationArray= eval(msg.d);
	
	// Check if all the members are ready, then call Redraw();
	if(this.MetroStationLineArray != null){
		this.ReDrawFunction();
	}
}

MetroStationClient.prototype.OnGetMetroStationLineArraySuccess = function(msg){
	this.MetroStationLineArray= eval(msg.d);
	
	for(var i = 0; i < this.MetroStationLineArray.length; i++) {
		var p1Obj = eval('(' + this.MetroStationLineArray[i].LineGraph.p1 + ')');
		this.MetroStationLineArray[i].LineGraph.p1 = p1Obj;
		
		var p2Obj = eval('(' + this.MetroStationLineArray[i].LineGraph.p2+ ')');
		this.MetroStationLineArray[i].LineGraph.p2 = p2Obj;
	}	
	
	// Check if all the members are ready, then call Redraw();
	if(this.MetroStationArray != null){
		this.ReDrawFunction();
	}
}

MetroStationClient.prototype.OnError = function(response){
	alert(response.statusText);
}