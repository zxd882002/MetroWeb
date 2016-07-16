function DrawStation(metroStation) {
    $('#metroCanvas').draw(metroStation.StationGraph);
    $('#metroCanvas').draw(metroStation.NameGraph);
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
    // var scaleVal = 1.1;
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