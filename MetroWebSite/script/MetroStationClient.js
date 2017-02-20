function MetroStationClient(ReDraw) 
{
	this.MetroStationArray = null;
	this.MetroStationLineArray = null;
	this.ReDrawFunction = ReDraw;
};

MetroStationClient.prototype.GetMetroStationArray = function() {
	var metroStationClient = this;
	$.ajax({
        type: 'post',
        url: 'http://localhost:8732/MetroWebService.svc/GetStationInfos',
        contentType: 'text/json',
        data: null,
        success: function (msg){
			metroStationClient.OnGetMetroStationArraySuccess.call(metroStationClient, msg);
			},
        error: function (response){
			metroStationClient.OnError.call(metroStationClient, response);
			},
    });
};

MetroStationClient.prototype.GetMetroStationLineArray = function(){
	var metroStationClient = this;
	$.ajax({
        type: 'post',
        url: 'http://localhost:8732/MetroWebService.svc/GetLineInfos',
        contentType: 'text/json',
        data: null,
        success: function (msg){
			metroStationClient.OnGetMetroStationLineArraySuccess.call(metroStationClient, msg);
			},
        error: function (response){
			metroStationClient.OnError.call(metroStationClient, response);
			},
    });
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