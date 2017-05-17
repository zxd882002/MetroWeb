function RightPanelUpdator(rightPanel) {
    this.rightPanel = rightPanel;
    this.stationInfoHeader = rightPanel.find(".stationInfo > .stationInfoHeader");
    this.stationInfoContainer = rightPanel.find(".stationInfo > .stationInfoContainer");
    this.setStartButton = rightPanel.find(".startEndSet > .SetStart");
    this.setEndButton = rightPanel.find(".startEndSet > .SetEnd");
    this.clearSetButton = rightPanel.find(".startEndSet > .ClearSet");
    this.calculateButton = rightPanel.find(".startEndSet > .Calculate");

    RightPanelUpdator.prototype.update = function (stationInfo) {
        this.stationInfoHeader.text(stationInfo.StationName);

        this.stationInfoContainer.text("");
        for (var i = 0; i < stationInfo.StationLines.length; i++) {
            var stationLine = stationInfo.StationLines[i];
            var div = $('<div/>');
            var lineIdSpan = $('<span/>').text(stationLine.LineInfo.LineId).appendTo(div);
            var routeSpan = $('<span/>').text(stationLine.LineInfo.LineRoute).appendTo(div);
            var startEndTimeSpan = $('<span/>').text(stationLine.StartEndTime).appendTo(div);
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

    RightPanelUpdator.prototype.showClearSetButton = function(){
        this.clearSetButton.show();
    }

    RightPanelUpdator.prototype.showCalculateButton = function(){
        this.calculateButton.show();
    }
}