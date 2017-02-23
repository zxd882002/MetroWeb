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
    height: 15,
	click: function(node){
		$('.footer').text("点击" + node.stationName);
	}
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

var metroStationLineGraphBase = {
	layer: true,
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'path',
    strokeWidth: 5,
}

function DrawStation(metroStation) {
	var metroStationGraph =	$.extend({}, metroStationGraphBase, metroStation.StationGraph);
	metroStationGraph.stationId = metroStation.id;
	metroStationGraph.stationName =  metroStation.NameGraph.text;
    $('#metroCanvas').draw(metroStationGraph);
	
	var metroStationName = $.extend({}, metroStationNameGraphBase, metroStation.NameGraph);
    $('#metroCanvas').draw(metroStationName);
}

function DrawLine(stationLine) {
	var metroStationLineGraph = $.extend({}, metroStationLineGraphBase, stationLine.LineGraph);
    $('#metroCanvas').draw(metroStationLineGraph);
}

function ReDraw() {
	$('#metroCanvas').clearCanvas().drawLayers();		
	
	// calculate the scale value
	var height = $(".canvasContainer").height();
    var width = $(".canvasContainer").width();
    var scale1 = height / 528;
    var scale2 = width / 1366;
    var scaleVal = scale1 < scale2 ? scale1 : scale2;
    $('#metroCanvas').scaleCanvas({ scale: scaleVal }).drawLayers();
	
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
	var stationLineArray = metroStationClient.MetroStationLineArray;
    for (var j = 0; j < stationLineArray.length; j++) {
        DrawLine(stationLineArray[j]);
    }
	
	var metroStationArray = metroStationClient.MetroStationArray;
    for (var i = 0; i < metroStationArray.length; i++) {
        DrawStation(metroStationArray[i]);
    }
}

var metroStationClient;

$(document).ready(function () {
	
	// when the window resizes
	/*
	$(window).resize(function(e){		
		var height2 = $(".canvasContainer").height();
		var width2 = $(".canvasContainer").width();
		$('.footer').text("新大小：（" + width2 + " * " +height2 + ")" );
		ReDraw();
	});
	*/

    // scroll
    $('#metroCanvas').bind('mousewheel', function(e){
		scaleVal  = e.originalEvent.wheelDelta > 0 ? 1.05 : 0.95;
		$('.footer').text();
		$('#metroCanvas').scaleCanvas({ 
			x: e.clientX - $("#metroCanvas").position().left, 
			y: e.clientY - $("#metroCanvas").position().top, 
			scale: scaleVal }).drawLayers();
    });		
	
	// set the canvas to fill the whole page
    var height = $(".canvasContainer").height();
    var width = $(".canvasContainer").width();
    $('#metroCanvas').attr({ height: height, width: width });
	
	// Show waiting message	
	$('#metroCanvas').draw({
	layer: true,
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'text',
    strokeStyle: 'black',
    strokeWidth: 1,    
    fontSize: 4,
    fontFamily: 'SimSun',
	text: "请稍等",
	x: width / 2,
	y: height / 2
	});
	
	// Get the data from database
	metroStationClient = new MetroStationClient(ReDraw);
	metroStationClient.GetMetroStationArray();
	metroStationClient.GetMetroStationLineArray();
})