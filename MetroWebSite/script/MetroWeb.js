var metroStationGraphBase = {
	layer: true,
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'ellipse',
    strokeStyle: 'black',
    fillStyle: 'white',
    strokeWidth: 2,
    width: 15,
    height: 15
}

var metroStationNameGraphBase = {
	layer: true,
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'text',
    strokeStyle: 'black',
    strokeWidth: 1,    
    fontSize: 4,
    fontFamily: 'SimSun',
}

function DrawStation(metroStation) {
	var metroStationGraph =	$.extend({}, metroStationGraphBase, metroStation.StationGraph);
    $('#metroCanvas').draw(metroStationGraph);
	
	var metroStationName = $.extend({}, metroStationNameGraphBase, metroStation.NameGraph);
    $('#metroCanvas').draw(metroStationName);
}

function DrawLine(stationLine) {
    $('#metroCanvas').draw(stationLine.LineGraph);
}

$(document).ready(function () {
    // set the canvas to fill the whole page
    var height = $(".canvasContainer").height();
    var width = $(".canvasContainer").width();
    $('#metroCanvas').attr({ height: height, width: width });

    // calculate the scale value
    //height = 528
    //width = 1366
    var scale1 = height / 528;
    var scale2 = width / 1366;
    var scaleVal = scale1 < scale2 ? scale1 : scale2;
    $('#metroCanvas').scaleCanvas({ scale: scaleVal });

    // draw a dragable element so that we could drag it on white places
    $('#metroCanvas').drawRect({
        layer: true,
        draggable: true,
        groups: ['Metros'],
        dragGroups: ['Metros'],
        fillStyle: 'white',
        x: width * -1, y: height * -1,
        width: width * 3,
        height: height * 3,
        fromCenter: false
    });

    // draw element
    for (var j = 0; j < stationLineArray.length; j++) {
        DrawLine(stationLineArray[j]);
    }
    for (var i = 0; i < metroStationArray.length; i++) {
        DrawStation(metroStationArray[i]);
    }
})