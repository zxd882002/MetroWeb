function AjaxHelper(url, callbackObj, successCallback, errorCallback){
	this.url = url;
	this.callbackObj = callbackObj;
	this.successCallback = successCallback;
	this.errorCallback = errorCallback;
	AjaxHelper.prototype.CallWCFAsync = function()
	{
		$.ajax({
        type: 'post',
        url: this.url,
        contentType: 'text/json',
        data: null,
        success: function (msg){
			successCallback.call(callbackObj, msg)
			},
        error: function (response){
			errorCallback.call(callbackObj, msg)
			},
    });
	}
}