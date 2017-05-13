function DefaultController(metroCanvas, canvasContainer, header, footer, rightPanel) {
    this.metroCanvas = metroCanvas;
    this.canvasContainer = canvasContainer;
    this.header = header;
    this.footer = footer;
    this.metroPainter = new MetroPainter(metroCanvas, canvasContainer);
    this.metroWebWcfClient = new MetroWebWcfClient();
    this.rightPanelUpdator = new RightPanelUpdator(rightPanel)
    this.metroStationArray = null;
    this.metroStationLineArray = null;
    this.clickedMetroStation = null;
    this.clickedMetroStationGraph = null;
    this.stationStart = null;
    this.stationStartGraph = null;
    this.stationEnd = null;
    this.stationEndGraph = null;

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

        // Hide the right pannel
        // todo: currently we just clear all buttons
        this.rightPanelUpdator.clearAllSetButtons();
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
        // clear the select dot from painter
        if(this.clickedMetroStation != null){
            this.metroPainter.clearSelectedDot(this.clickedMetroStationGraph);
        }

        // find the node
        this.metroStationArray.some(function (metroStation) {
            if (metroStation.StationId == node.stationId) {
                this.clickedMetroStation = metroStation;
                return true;
            }
            return false;
        }, this);

        // add a dot from the painter
        this.clickedMetroStationGraph = this.metroPainter.drawSelectedDot(this.clickedMetroStation);

        // update the right pannel
        this.rightPanelUpdator.update(this.clickedMetroStation);        
        this.updateStartEndButton();        
    }

    DefaultController.prototype.onClickSetStartButton = function () {
        this.stationStart = this.clickedMetroStation;
        if (this.clickNodeIsSetEnd()) {
            this.stationEnd = null;
        }
        this.updateStartEndButton();  
    }

    DefaultController.prototype.onclickSetEndButton = function () {
        this.stationEnd = this.clickedMetroStation;
        if (this.clickNodeIsSetStart()) {
            this.stationStart = null;
        }
        this.updateStartEndButton();  
    }

    DefaultController.prototype.onClickClearSetButton = function () {
        if (this.clickNodeIsSetStart()) {
            this.stationStart = null;
        }
        if (this.clickNodeIsSetEnd()) {
            this.stationEnd = null;
        }
        this.updateStartEndButton();  
    }

    DefaultController.prototype.clickNodeIsSetStart = function () {
        return this.stationStart == this.clickedMetroStation;
    }

    DefaultController.prototype.clickNodeIsSetEnd = function () {
        return this.stationEnd == this.clickedMetroStation;
    }

    DefaultController.prototype.updateStartEndButton = function (){
        this.rightPanelUpdator.clearAllSetButtons();
        if (!this.clickNodeIsSetStart()) {
            this.rightPanelUpdator.showSetStartButton();
        }

        if (!this.clickNodeIsSetEnd()) {
            this.rightPanelUpdator.showSetEndButton();
        }

        if (this.clickNodeIsSetStart() || this.clickNodeIsSetEnd()) {
            this.rightPanelUpdator.showClearSetButton();
        }
    }
}