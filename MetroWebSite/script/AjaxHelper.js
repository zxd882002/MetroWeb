function AjaxHelper() {
	AjaxHelper.prototype.CallWCFAsync = function (url, callbackObj, successCallback, errorCallback) {
		$.ajax({
			type: 'post',
			url: url,
			contentType: 'text/json',
			data: null,
			success: function (msg) {
				successCallback.call(callbackObj, msg)
			},
			error: function (response) {
				errorCallback.call(callbackObj, response)
			},
		});
	}
}