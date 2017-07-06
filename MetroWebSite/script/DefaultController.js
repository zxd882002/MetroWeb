function DefaultController(metroCanvas, canvasContainer, header, footer, contextPanel, toolTip) {
    // website element
    this.metroCanvas = metroCanvas;
    this.canvasContainer = canvasContainer;
    this.header = header;
    this.footer = footer;

    // lower objects
    this.metroPainter = new MetroPainter(metroCanvas, canvasContainer);
    this.metroWebWcfClient = new MetroWebWcfClient();
    this.contextPanelUpdator = new ContextPanelUpdator(contextPanel);
    this.calculateToolTipUpdator = new CalculateToolTipUpdator(toolTip);

    // models
    this.metroStationArray = null;
    this.metroStationLineArray = null;
    this.clickedMetroStation = null;
    this.stationStart = null;
    this.stationEnd = null;
    this.routedNodeList = [];

    DefaultController.prototype.initializeCanvas = function () {
        // set the canvas to fill the whole page
        this.metroPainter.fullFillCanvas();
        this.contextPanelUpdator.canvasRight = this.metroCanvas.position().left + this.metroCanvas.width();
        this.contextPanelUpdator.canvasBotton = this.metroCanvas.position().top + this.metroCanvas.height();
        this.calculateToolTipUpdator.show(this.metroCanvas.position().left + this.metroCanvas.width());

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
        this.contextPanelUpdator.hide();
    }

    DefaultController.prototype.onResize = function (e) {
        // set the canvas to fill the whole page
        this.metroPainter.fullFillCanvas();

        // output the new size
        var height = canvasContainer.height();
        var width = canvasContainer.width();
        this.footer.text("新大小：（" + width + " * " + height + ")");

        // this.onDrawCanvas();

        this.contextPanelUpdator.hide();
    }

    DefaultController.prototype.onDrag = function (node) {
        this.contextPanelUpdator.hide();
    }

    DefaultController.prototype.onDrawCanvas = function () {
        this.metroPainter.clearEntireCanvas();
        this.metroPainter.drawBackGround(this.onDrag, this);
        this.metroPainter.drawLineArray(this.metroStationLineArray, this.onDrag, this);
        this.metroPainter.drawStationArray(this.metroStationArray, this.onClickNode, this.onDrag, this);
    }

    DefaultController.prototype.onClickNode = function (nodeLabel) {
        // clear the select node from painter
        if (this.clickedMetroStation != null) {
            this.metroPainter.clearSelectedNode(this.getNodeByStation(this.clickedMetroStation));
            this.clickedMetroStation = null;
        }

        // find node by the selected node or label position
        var node = this.findNodeByPosition(nodeLabel.x, nodeLabel.y, nodeLabel.type == 'image');

        // draw node from the painter
        this.metroPainter.drawSelectedNode(node);

        // update the context pannel
        this.clickedMetroStation = this.getStationByNode(node);
        this.contextPanelUpdator.show(
            this.clickedMetroStation,
            this.clickNodeIsSetStart(),
            this.clickNodeIsSetEnd(),
            node.eventX,
            node.eventY + this.header.height());
    }

    DefaultController.prototype.onClickSetStartButton = function () {
        // clear route label
        if (this.routedNodeList != null && this.routedNodeList.length > 0) {
            this.metroPainter.clearRoute();
            this.routedNodeList = [];
        }

        if (this.clickNodeIsSetStart()) {
            // if the node is selected
            this.metroPainter.clearStartLabel();
            this.stationStart = null;
            this.calculateToolTipUpdator.fadeOut(this.calculateToolTipUpdator.hideCalculateButton, this.calculateToolTipUpdator);
        } else {
            // clear start button if set in other node
            if (this.stationStart != null) {
                this.metroPainter.clearStartLabel();
                this.stationStart = null;
            }

            // clear start and end button if current node has already been set
            this.clearCurrentLabel();

            // set current node to start node
            this.stationStart = this.clickedMetroStation;

            // set current node label
            var clickedNode = this.getNodeByStation(this.clickedMetroStation);
            var startLabel = new Object();
            startLabel.x = clickedNode.x;
            startLabel.y = clickedNode.y;
            this.metroPainter.drawStartLabel(startLabel, this.onClickNode, this);
        }

        this.contextPanelUpdator.hide();

        if (this.stationStart != null && this.stationEnd != null) {
            this.calculateToolTipUpdator.showCalculateButton();
            this.calculateToolTipUpdator.fadeIn(null, null);
        }
    }

    DefaultController.prototype.onclickSetEndButton = function () {
        // clear route label
        if (this.routedNodeList != null && this.routedNodeList.length > 0) {
            this.metroPainter.clearRoute();
            this.routedNodeList = [];
        }

        if (this.clickNodeIsSetEnd()) {
            // if the node is selected
            this.metroPainter.clearEndLabel();
            this.stationEnd = null;
            this.calculateToolTipUpdator.fadeOut(this.calculateToolTipUpdator.hideCalculateButton, this.calculateToolTipUpdator);
        } else {
            // clear end button if set in other node
            if (this.stationEnd != null) {
                this.metroPainter.clearEndLabel();
                this.stationEnd = null;
            }

            // clear start and end button if current node has already been set
            this.clearCurrentLabel();

            // set current node to end node
            this.stationEnd = this.clickedMetroStation;

            // set current node label
            var clickedNode = this.getNodeByStation(this.clickedMetroStation);
            var endLabel = new Object();
            endLabel.x = clickedNode.x;
            endLabel.y = clickedNode.y;
            this.metroPainter.drawEndLabel(endLabel, this.onClickNode, this);
        }
        this.contextPanelUpdator.hide();

        if (this.stationStart != null && this.stationEnd != null) {
            this.calculateToolTipUpdator.showCalculateButton();
            this.calculateToolTipUpdator.fadeIn(null, null);
        }
    }

    DefaultController.prototype.onClickCalculatorButton = function () {
        this.calculateToolTipUpdator.hideCalculateButton();
        this.calculateToolTipUpdator.showCalculatingSpan();

        this.metroWebWcfClient.GetNearestRoute(
            this.stationStart.StationName, this.stationStart.StationLines[0].LineInfo.LineId,
            this.stationEnd.StationName, this.stationEnd.StationLines[0].LineInfo.LineId,
            function (routedStationList) {
                // get the correct note path
                this.routedNodeList = new Array(routedStationList.length - 2);
                for (var i = 1; i < routedStationList.length - 1; i++) {
                    var node = this.getNodeByStation(routedStationList[i]);
                    this.routedNodeList[i - 1] = new Object();
                    this.routedNodeList[i - 1].x = node.x;
                    this.routedNodeList[i - 1].y = node.y;
                }
                this.metroPainter.clearRoute();
                this.metroPainter.drawRoute(this.routedNodeList, this.onClickNode, this);

                this.calculateToolTipUpdator.hideCalculatingSpan();
                this.calculateToolTipUpdator.showCalculatedSpan();
                var that = this;
                setTimeout(
                    function () {
                        that.calculateToolTipUpdator.fadeOut(that.calculateToolTipUpdator.hideCalculatedSpan, that.calculateToolTipUpdator);
                    }, 1000);
            }, this);
    }

    DefaultController.prototype.clickNodeIsSetStart = function () {
        return this.stationStart == this.clickedMetroStation;
    }

    DefaultController.prototype.clickNodeIsSetEnd = function () {
        return this.stationEnd == this.clickedMetroStation;
    }

    DefaultController.prototype.clearCurrentLabel = function () {
        if (this.clickNodeIsSetEnd()) {
            this.stationEnd = null;
            this.metroPainter.clearEndLabel();
        }

        if (this.clickNodeIsSetStart()) {
            this.stationStart = null;
            this.metroPainter.clearStartLabel();
        }
    }

    DefaultController.prototype.findNodeByPosition = function (x, y, isLabel) {
        var node = null;
        var layers = this.metroCanvas.getLayers();
        layers.some(function (layer) {
            if (typeof layer.stationId !== 'undefined' &&
                typeof layer.x !== 'undefined' &&
                typeof layer.y !== 'undefined') {
                if (layer.x == x && layer.y == y) {
                    node = layer;
                    return true;
                }
                if (isLabel && layer.x == x && layer.y == y + 20) {
                    node = layer;
                    return true;
                }
            }
            return false;
        }, this);
        return node;
    }

    DefaultController.prototype.getNodeByStation = function (station) {
        var node = null;
        var layers = this.metroCanvas.getLayers();
        layers.some(function (layer) {
            if (typeof layer.stationId !== 'undefined') {
                if (station.StationId == layer.stationId) {
                    node = layer;
                    return true;
                }
            }
            return false;
        }, this);
        return node;
    }

    DefaultController.prototype.getStationByNode = function (node) {
        var station = null;
        this.metroStationArray.some(function (metroStation) {
            if (metroStation.StationId == node.stationId) {
                station = metroStation;
                return true;
            }
            return false;
        }, this);
        return station;
    }
}