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
            this.stationInfoContainer.append("<div>" + stationLine.StartTime + "</div>")
        }
    }
}