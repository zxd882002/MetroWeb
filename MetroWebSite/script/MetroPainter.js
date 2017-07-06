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
    click: function (node) {
        node.onClick.call(node.calleeObj, node)
    },
    dragstart: function(node) {
        node.onDrag.call(node.calleeObj, node)
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
    dragstart: function(node) {
        node.onDrag.call(node.calleeObj, node)
    }
}

var metroStationLineGraphBase = {
    layer: true,
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'path',
    strokeWidth: 5,
     dragstart: function(node) {
        node.onDrag.call(node.calleeObj, node)
    }
}

var startLabelBase = {
    layer: true,
    name: 'start',
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'image',
    source: 'img/location-blue.png',
    click: function (node) {
        node.onClick.call(node.calleeObj, node)
    }
}

var endLabelBase = {
    layer: true,
    name: 'end',
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'image',
    source: 'img/location-orange.png',
    click: function (node) {
        node.onClick.call(node.calleeObj, node)
    }
}

var routeLabelBase = {
    layer: true,
    name: 'route',
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'image',
    source: 'img/position.png'
}

function MetroPainter(metroCanvas, canvasContainer) {
    this.metroCanvas = metroCanvas;
    this.canvasContainer = canvasContainer;
    this.width = canvasContainer.width();
    this.height = canvasContainer.height();
    this.routeArray = new Array();

    MetroPainter.prototype.drawStationArray = function (metroStationArray, onClickFunction, onDragFunction, calleeObj) {
        for (var i = 0; i < metroStationArray.length; i++) {
            this.drawStation(metroStationArray[i], onClickFunction, onDragFunction, calleeObj);
        }
    }

    MetroPainter.prototype.drawStation = function (metroStation, onClickFunction, onDragFunction, calleeObj) {
        var metroStationGraph = $.extend({}, metroStationGraphBase, metroStation.StationGraph);
        metroStationGraph.name = 'stationNode_' + metroStation.StationId + '_' + metroStation.NameGraph.text;
        metroStationGraph.onClick = onClickFunction;
        metroStationGraph.onDrag = onDragFunction;
        metroStationGraph.calleeObj = calleeObj;
        metroStationGraph.stationId = metroStation.StationId;
        metroStationGraph.stationName = metroStation.NameGraph.text;
        this.metroCanvas.draw(metroStationGraph);

        var metroStationName = $.extend({}, metroStationNameGraphBase, metroStation.NameGraph);
        metroStationName.name = 'stationName_' + metroStation.StationId + '_' + metroStation.NameGraph.text;
        metroStationGraph.onDrag = onDragFunction;
        metroStationGraph.calleeObj = calleeObj;
        this.metroCanvas.draw(metroStationName);
    }

    MetroPainter.prototype.drawLineArray = function (metroStationLineArray, onDragFunction, calleeObj) {
        for (var j = 0; j < metroStationLineArray.length; j++) {
            this.drawLine(metroStationLineArray[j], onDragFunction, calleeObj);
        }
    }

    MetroPainter.prototype.drawLine = function (stationLine, onDragFunction, calleeObj) {
        var metroStationLineGraph = $.extend({}, metroStationLineGraphBase, stationLine.LineGraph);
        metroStationLineGraph.name = 'line_' + stationLine.LineId;
        metroStationLineGraph.onDrag = onDragFunction;
        metroStationLineGraph.calleeObj = calleeObj;
        this.metroCanvas.draw(metroStationLineGraph);
    }

    MetroPainter.prototype.clearEntireCanvas = function () {
        this.metroCanvas.removeLayers();
        this.metroCanvas.clearCanvas();
    }

    MetroPainter.prototype.scaleCanvas = function () {
        if (needScale) {
            var height = this.height;
            var width = this.width;
            var scale1 = this.height / 528;
            var scale2 = this.width / 1366;
            var scaleVal = scale1 < scale2 ? scale1 : scale2;
            this.metroCanvas.scaleCanvas({
                scale: scaleVal
            }).drawLayers();
        }
    }

    MetroPainter.prototype.drawBackGround = function (onDragFunction, calleeObj) {
        this.metroCanvas.drawRect({
            layer: true,
            name: 'background',
            draggable: true,
            groups: ['Metros'],
            dragGroups: ['Metros'],
            fillStyle: '#EEEEFF',
            x: this.width * -1,
            y: this.height * -1,
            width: this.width * 3,
            height: this.height * 3,
            fromCenter: false,
            dragstart: function(node) {
                onDragFunction.call(calleeObj, node)
            }
        });
    }

    MetroPainter.prototype.drawWaitingMessage = function () {
        this.metroCanvas.draw({
            layer: true,
            name: 'waitingMessage',
            draggable: true,
            groups: ['Metros'],
            dragGroups: ['Metros'],
            type: 'text',
            strokeStyle: 'black',
            strokeWidth: 1,
            fontSize: 4,
            fontFamily: 'SimSun',
            text: "请稍等",
            x: this.width / 2,
            y: this.height / 2
        });
    }

    MetroPainter.prototype.fullFillCanvas = function () {
        this.metroCanvas.attr({
            height: this.canvasContainer.height(),
            width: this.canvasContainer.width()
        });
        this.width = canvasContainer.width();
        this.height = canvasContainer.height();
    }

    MetroPainter.prototype.scaleCanvas = function (x, y, scaleVal) {
        this.metroCanvas.scaleCanvas({
            x: x,
            y: y,
            scale: scaleVal
        }).drawLayers();
    }

    MetroPainter.prototype.drawSelectedNode = function (selectedMetroStation) {
        //selectedMetroStation.strokeStyle = 'black';
        selectedMetroStation.strokeWidth = 5;
    }

    MetroPainter.prototype.clearSelectedNode = function (selectedMetroStation) {
        //selectedMetroStation.strokeStyle = 'black';
        selectedMetroStation.strokeWidth = 2;
    }

    MetroPainter.prototype.drawStartLabel = function (startMetroStation, onClickFunction, calleeObj) {
        var metroStationGraph = $.extend({}, startLabelBase, startMetroStation);
        metroStationGraph.y -= 20;
        metroStationGraph.onClick = onClickFunction;
        metroStationGraph.calleeObj = calleeObj;
        this.metroCanvas.draw(metroStationGraph);
    }

    MetroPainter.prototype.clearStartLabel = function () {
        this.metroCanvas.removeLayer('start').drawLayers();
    }

    MetroPainter.prototype.drawEndLabel = function (endMetroStation, onClickFunction, calleeObj) {
        var metroStationGraph = $.extend({}, endLabelBase, endMetroStation);
        metroStationGraph.y -= 20;
        metroStationGraph.onClick = onClickFunction;
        metroStationGraph.calleeObj = calleeObj;
        this.metroCanvas.draw(metroStationGraph);
    }

    MetroPainter.prototype.clearEndLabel = function () {
        this.metroCanvas.removeLayer('end').drawLayers();
    }

    MetroPainter.prototype.drawRoute = function (stationList, onClickFunction, calleeObj) {
        for (var i = 0; i < stationList.length; i++) {
            var metroStationGraph = $.extend({}, routeLabelBase, stationList[i]);
            metroStationGraph.y -= 15;
            metroStationGraph.name = "route_" + i;
            metroStationGraph.onClick = onClickFunction;
            metroStationGraph.calleeObj = calleeObj;
            this.metroCanvas.draw(metroStationGraph);
            this.routeArray.push(metroStationGraph);
        }
    }

    MetroPainter.prototype.clearRoute = function () {
        this.routeArray.forEach(function (route) {
            this.metroCanvas.removeLayer(route.name).drawLayers();
        }, this);
        this.routeArray = [];
    }
}