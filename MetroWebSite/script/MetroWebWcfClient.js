function MetroWebWcfClient() {
	this.ajaxHelper = new AjaxHelper();
	this.getStationInfosDeferred = $.Deferred();
	this.getLineInfosDeferred = $.Deferred();
	this.getNearestRouteDefferred = $.Deferred();
	this.baseUrl = 'http://localhost:8732/MetroWebService.svc/'

	MetroWebWcfClient.prototype.GetStationInfos = function (callback, callbackObj) {
		this.getStationInfosDeferred.done(function (value) {
			callback.call(callbackObj, value);
		});

		var method = 'GetStationInfos';
		var successCallback = this.OnGetMetroStationArraySuccess;
		var errorCallback = this.OnError;
		this.ajaxHelper.CallWCFAsync(this.baseUrl + method, this, successCallback, errorCallback, null);
	}

	MetroWebWcfClient.prototype.GetLineInfos = function (callback, callbackObj) {
		this.getLineInfosDeferred.done(function (routeStationList) {
			callback.call(callbackObj, routeStationList);
		});

		var method = 'GetLineInfos';
		var successCallback = this.OnGetMetroStationLineArraySuccess;
		var errorCallback = this.OnError;
		this.ajaxHelper.CallWCFAsync(this.baseUrl + method, this, successCallback, errorCallback, null);
	}

	MetroWebWcfClient.prototype.GetNearestRoute = function (		
		fromStationName, fromLine,
		toStationName, toLine,
		callback, callbackObj){
		this.getNearestRouteDefferred.done(function (value) {
			callback.call(callbackObj, value);
		});

		var method = 'GetNearestRoute';
		var successCallback = this.OnGetNearestRouteSuccess;
		var errorCallback = this.OnError;
		var sendData = '{"fromStationName":"' + fromStationName + '","fromLine":"' + fromLine +
                   '","toStationName":"' + toStationName + '","toLine":"' + toLine + '"}';
		this.ajaxHelper.CallWCFAsync(this.baseUrl + method, this, successCallback, errorCallback, sendData);
	}

	MetroWebWcfClient.prototype.OnGetMetroStationArraySuccess = function (msg) {
		var metroStationArray = eval(msg.d);
		this.getStationInfosDeferred.resolve(metroStationArray);
	}

	MetroWebWcfClient.prototype.OnGetMetroStationLineArraySuccess = function (msg) {
		var metroStationLineArray = eval(msg.d);

		for (var i = 0; i < metroStationLineArray.length; i++) {
			var p1Obj = eval('(' + metroStationLineArray[i].LineGraph.p1 + ')');
			metroStationLineArray[i].LineGraph.p1 = p1Obj;

			var p2Obj = eval('(' + metroStationLineArray[i].LineGraph.p2 + ')');
			metroStationLineArray[i].LineGraph.p2 = p2Obj;
		}

		this.getLineInfosDeferred.resolve(metroStationLineArray);
	}

	MetroWebWcfClient.prototype.OnGetNearestRouteSuccess = function (msg){
		var routeStationList = eval(msg.d);
		this.getNearestRouteDefferred.resolve(routeStationList);
		this.getNearestRouteDefferred = $.Deferred();
	}

	MetroWebWcfClient.prototype.OnError = function (response) {
		alert(response.statusText);
	}
}