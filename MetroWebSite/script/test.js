function getStationName() {
    var sendData = '{"stationId":"' + $("#StationId").val() + '"}';
    //alert(sendData);
    $.ajax({
        type: 'post',
        url: 'http://andy-pc:8732/MetroWebService.svc/GetStationNameByStationId',
        contentType: 'text/json',
        data: sendData,
        success: function (msg) {
            station = eval(msg.d);
            $('#StationName').text(station.StationName);
        },
        error: function (response) {
            alert(response.statusText);
        }
    });
}