function getStations() {
	$.ajax({
        type: 'post',
        url: 'http://localhost:8732/MetroWebService.svc/GetStationInfos',
        contentType: 'text/json',
        data: null,
        success: function (msg) {
            var stations = eval(msg.d);
            $('#Stations').text(stations[0].NameGraph.text);
        },
        error: function (response) {
            alert(response.statusText);
        }
    });
}

function getLines(){
	$.ajax({
        type: 'post',
        url: 'http://localhost:8732/MetroWebService.svc/GetLineInfos',
        contentType: 'text/json',
        data: null,
        success: function (msg) {
            var lines = eval(msg.d);
            $('#Lines').text(lines[0].LineGraph.strokeStyle);
        },
        error: function (response) {
            alert(response.statusText);
        }
    });
}

function getStationName() {
    var sendData = '{"stationId":"' + $("#StationId").val() + '"}';
    $.ajax({
        type: 'post',
        url: 'http://localhost:8732/MetroWebService.svc/GetStationByStationId',
        contentType: 'text/json',
        data: sendData,
        success: function (msg) {
            var station = eval(msg.d);
            $('#StationName').text(station.NameGraph.text);
        },
        error: function (response) {
            alert(response.statusText);
        }
    });
}

function getRoute() {
    var fromStationName = $('#FromStationName').val();
    var fromLine = $('#FromLine').val();
    var toStationName = $('#ToStationName').val();
    var toLine = $('#ToLine').val();
    var sendData = '{"fromStationName":"' + fromStationName + '","fromLine":"' + fromLine +
                   '","toStationName":"' + toStationName + '","toLine":"' + toLine + '"}';
    $.ajax({
        type: 'post',
        url: 'http://localhost:8732/MetroWebService.svc/GetNearestRoute',
        contentType: 'text/json',
        data: sendData,
        success: function (msg) {
            var route = msg.d;
            $('#route').html(route);
        },
        error: function (response) {
            alert(response.statusText);
        }
    });
}

function html_decode(str) {
    var s = "";
    if (str.length == 0) return "";
    s = str.replace(/>/g, "&");
    s = s.replace(/</g, "<");
    s = s.replace(/>/g, ">");
    s = s.replace(/ /g, " ");
    s = s.replace(/'/g, "\'");
    s = s.replace(/"/g, "\"");
    s = s.replace(/<br>/g, "\n"); 
    return s;
}