function RightPanelUpdator(rightPanel) {
    this.rightPanel = rightPanel;
    this.stationInfoHeaderStationName = rightPanel.find(".stationInfo > .stationInfoHeader > .stationName");
    this.stationInfoContainer = rightPanel.find(".stationInfo > .stationInfoContainer");
    this.setStartButton = rightPanel.find(".startEndSet > .SetStart");
    this.setEndButton = rightPanel.find(".startEndSet > .SetEnd");
    this.clearSetButton = rightPanel.find(".startEndSet > .ClearSet");
    this.calculateButton = rightPanel.find(".startEndSet > .Calculate");

    RightPanelUpdator.prototype.show = function (x, y) {
        this.rightPanel.css('left', x);
        this.rightPanel.css('top', y);
        this.rightPanel.show();
    }

    RightPanelUpdator.prototype.hide = function () {
        this.rightPanel.hide();
    }

    RightPanelUpdator.prototype.update = function (stationInfo) {
        this.stationInfoHeaderStationName.text(stationInfo.StationName);

        this.stationInfoContainer.text("");
        for (var i = 0; i < stationInfo.StationLines.length; i++) {
            var stationLine = stationInfo.StationLines[i];
            var div = $('<div/>');
            var lineIdSpan = $('<span class="lineId" />').text(stationLine.LineInfo.LineId).css('background-color',stationLine.LineInfo.LineColor).appendTo(div);
            var routeSpan = $('<span/>').text(stationLine.LineInfo.LineRoute.FromStationName).appendTo(div);
            var routeSpan = $('<span/>').text('-').appendTo(div);
            var routeSpan = $('<span/>').text(stationLine.LineInfo.LineRoute.ToStationName).appendTo(div);
            var startEndTimeSpan = $('<span/>').text(stationLine.StartEndTime.StartTime).appendTo(div);
            var routeSpan = $('<span/>').text('-').appendTo(div);
            var startEndTimeSpan = $('<span/>').text(stationLine.StartEndTime.EndTime).appendTo(div);
            div.appendTo(this.stationInfoContainer);
        }
    }

    RightPanelUpdator.prototype.clearAllSetButtons = function () {
        this.setStartButton.hide();
        this.setEndButton.hide();
        this.clearSetButton.hide();
        this.calculateButton.hide();
    }

    RightPanelUpdator.prototype.showSetStartButton = function () {
        this.setStartButton.show();
    }

    RightPanelUpdator.prototype.showSetEndButton = function () {
        this.setEndButton.show();
    }

    RightPanelUpdator.prototype.showClearSetButton = function () {
        this.clearSetButton.show();
    }

    RightPanelUpdator.prototype.showCalculateButton = function () {
        this.calculateButton.show();
    }
}