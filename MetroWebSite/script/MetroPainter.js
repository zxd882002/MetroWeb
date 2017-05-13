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
    }
}

var metroStationDotBase = {
    layer: true,
    name: 'dot',
    draggable: true,
    groups: ['Metros'],
    dragGroups: ['Metros'],
    type: 'ellipse',
    strokeStyle: 'red',
    fillStyle: 'red',
    strokeWidth: 1,
    width: 5,
    height: 5,
    click: function (node) {
        node.onClick.call(node.calleeObj, node)
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

function MetroPainter(metroCanvas, canvasContainer) {
    this.metroCanvas = metroCanvas;
    this.canvasContainer = canvasContainer;
    this.width = canvasContainer.width();
    this.height = canvasContainer.height();

    MetroPainter.prototype.drawStationArray = function (metroStationArray, onClickFunction, calleeObj) {
        for (var i = 0; i < metroStationArray.length; i++) {
            this.drawStation(metroStationArray[i], onClickFunction, calleeObj);
        }
    }

    MetroPainter.prototype.drawStation = function (metroStation, onClickFunction, calleeObj) {
        var metroStationGraph = $.extend({}, metroStationGraphBase, metroStation.StationGraph);
        metroStationGraph.onClick = onClickFunction;
        metroStationGraph.calleeObj = calleeObj;
        metroStationGraph.stationId = metroStation.StationId;
        metroStationGraph.stationName = metroStation.NameGraph.text;
        this.metroCanvas.draw(metroStationGraph);

        var metroStationName = $.extend({}, metroStationNameGraphBase, metroStation.NameGraph);
        this.metroCanvas.draw(metroStationName);
    }

    MetroPainter.prototype.drawLineArray = function (metroStationLineArray) {
        for (var j = 0; j < metroStationLineArray.length; j++) {
            this.drawLine(metroStationLineArray[j]);
        }
    }

    MetroPainter.prototype.drawLine = function (stationLine) {
        var metroStationLineGraph = $.extend({}, metroStationLineGraphBase, stationLine.LineGraph);
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

    MetroPainter.prototype.drawBackGround = function () {
        this.metroCanvas.drawRect({
            layer: true,
            draggable: true,
            groups: ['Metros'],
            dragGroups: ['Metros'],
            fillStyle: '#EEEEFF',
            x: this.width * -1,
            y: this.height * -1,
            width: this.width * 3,
            height: this.height * 3,
            fromCenter: false
        });
    }

    MetroPainter.prototype.drawWaitingMessage = function () {
        this.metroCanvas.draw({
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

    MetroPainter.prototype.drawSelectedDot = function (selectedMetroStation) {
        var metroStationGraph = $.extend({}, metroStationDotBase, selectedMetroStation.StationGraph);        
        this.metroCanvas.draw(metroStationGraph);
        return metroStationGraph;
    }

    MetroPainter.prototype.clearSelectedDot = function (selectedMetroStationGraph) {
        this.metroCanvas.removeLayer('dot').drawLayers();
    }
}