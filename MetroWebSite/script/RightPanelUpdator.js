function RightPanelUpdator(rightPanel) {
    this.rightPanel = rightPanel;
    this.stationInfoHeader = rightPanel.find(".stationInfo > .stationInfoHeader");
    this.stationInfoContainer = rightPanel.find(".stationInfo > .stationInfoContainer");
    this.setStartButton = rightPanel.find(".startEndSet > .SetStart");
    this.setEndButton = rightPanel.find(".startEndSet > .SetEnd");
    this.clearSetButton = rightPanel.find(".startEndSet > .ClearSet");

    RightPanelUpdator.prototype.update = function (stationInfo) {
        this.stationInfoHeader.text(stationInfo.StationName);

        this.stationInfoContainer.text("");
        for(var i = 0; i < stationInfo.StationLines.length; i++)
        {
            var stationLine = stationInfo.StationLines[i];
            var div = $('<div/>');
            var lineIdSpan = $('<span/>').text(stationLine.LineInfo.LineId).appendTo(div);
            var routeSpan = $('<span/>').text(stationLine.LineInfo.LineRoute).appendTo(div);
            var startEndTimeSpan = $('<span/>').text(stationLine.StartEndTime).appendTo(div);
            div.appendTo(this.stationInfoContainer);  
        }
    }
}