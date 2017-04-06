function DefaultController(metroPainter) {
    this.metroPainter = metroPainter;
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
        $('.footer').text(scaleVal);

        // scale canvas
        this.metroPainter.scaleCanvas(scaleVal);
    }

    DefaultController.prototype.onResize = function (e) {
        // set the canvas to fill the whole page
        this.metroPainter.fullFillCanvas();

        // output the new size
        var height = $(".canvasContainer").height();
        var width = $(".canvasContainer").width();
        $('.footer').text("新大小：（" + width + " * " + height + ")");

        // ReDraw(false);
    }

    DefaultController.prototype.onDrawCanvas = function () {
        $('.footer').text("onDrawCanvas");
    }
}