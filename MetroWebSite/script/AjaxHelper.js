function AjaxHelper() {
	AjaxHelper.prototype.CallWCFAsync = function (url, callbackObj, successCallback, errorCallback, sendData) {
		$.ajax({
			type: 'post',
			url: url,
			contentType: 'text/json',
			data: sendData,
			success: function (msg) {
				successCallback.call(callbackObj, msg)
			},
			error: function (response) {
				errorCallback.call(callbackObj, response)
			},
		});
	}
}