function MetroWebWcfClient() {
	this.ajaxHelper = new AjaxHelper();
	this.getStationInfosDeferred = $.Deferred();
	this.getLineInfosDeferred = $.Deferred();

	MetroWebWcfClient.prototype.GetStationInfos = function (callback, callbackObj) {
		this.getStationInfosDeferred.done(function (value) {
			callback.call(callbackObj, value);
		});

		var url = 'http://localhost:8732/MetroWebService.svc/GetStationInfos';
		var successCallback = this.OnGetMetroStationArraySuccess;
		var errorCallback = this.OnError;
		this.ajaxHelper.CallWCFAsync(url, this, successCallback, errorCallback);
	}

	MetroWebWcfClient.prototype.GetLineInfos = function (callback, callbackObj) {
		this.getLineInfosDeferred.done(function (value) {
			callback.call(callbackObj, value);
		});

		var url = 'http://localhost:8732/MetroWebService.svc/GetLineInfos';
		var successCallback = this.OnGetMetroStationLineArraySuccess;
		var errorCallback = this.OnError;
		this.ajaxHelper.CallWCFAsync(url, this, successCallback, errorCallback);
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

	MetroWebWcfClient.prototype.OnError = function (response) {
		alert(response.statusText);
	}
}