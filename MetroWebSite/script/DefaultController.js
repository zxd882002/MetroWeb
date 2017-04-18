function DefaultController(metroCanvas, canvasContainer, header, footer) {
    this.metroCanvas = metroCanvas;
    this.canvasContainer = canvasContainer;
    this.header = header;
    this.footer = footer;
    this.metroPainter = new MetroPainter(metroCanvas, canvasContainer);
    this.metroWebWcfClient = new MetroWebWcfClient();
    this.metroStationArray = null;
    this.metroStationLineArray = null;

    DefaultController.prototype.initializeCanvas = function () {
        // set the canvas to fill the whole page
        this.metroPainter.fullFillCanvas();

        // Show waiting message	
        this.metroPainter.drawWaitingMessage();

        // Get the data from database        
        this.metroWebWcfClient.GetStationInfos(function (metroStationArray) {
            this.metroStationArray = metroStationArray;
            if (this.metroStationLineArray != null) {
                this.onDrawCanvas();
            }
        }, this);

        this.metroWebWcfClient.GetLineInfos(function (metroStationLineArray) {
            this.metroStationLineArray = metroStationLineArray;
            if (this.metroStationArray != null) {
                this.onDrawCanvas();
            }
        }, this);
    }

    DefaultController.prototype.onScroll = function (e) {
        // calculate the scaleVal
        var scaleVal = e.originalEvent.wheelDelta > 0 ? 1.05 : 0.95;

        // output scale value
        footer.text("x=" + e.clientX + ", y=" + (e.clientY - header.height()) + ", scale=" + scaleVal);

        // scale canvas
        this.metroPainter.scaleCanvas(e.clientX, e.clientY - header.height(), scaleVal);
    }

    DefaultController.prototype.onResize = function (e) {
        // set the canvas to fill the whole page
        this.metroPainter.fullFillCanvas();

        // output the new size
        var height = canvasContainer.height();
        var width = canvasContainer.width();
        this.footer.text("新大小：（" + width + " * " + height + ")");

        // this.onDrawCanvas();
    }

    DefaultController.prototype.onDrawCanvas = function () {
        this.metroPainter.clearEntireCanvas();
        this.metroPainter.drawBackGround();
        this.metroPainter.drawLineArray(this.metroStationLineArray);
        this.metroPainter.drawStationArray(this.metroStationArray, this.onClickNode, this);
    }

    DefaultController.prototype.onClickNode = function (node) {
        this.footer.text("点击" + node.stationName);
    }
}