function RightPanelUpdator(rightPanel) {
    this.rightPanel = rightPanel;
    this.stationInfoHeaderStationName = rightPanel.find(".stationInfo > .stationInfoHeader > .stationName");
    this.stationInfoContainer = rightPanel.find(".stationInfo > .stationInfoContainer");
    this.setStartButton = rightPanel.find(".startEndSet > .SetStart");
    this.setEndButton = rightPanel.find(".startEndSet > .SetEnd");

    RightPanelUpdator.prototype.show = function (stationInfo, isSetStartButton, isSetEndButton, x, y) {
        // station name
        this.stationInfoHeaderStationName.text(stationInfo.StationName);

        // station line info
        this.stationInfoContainer.text("");
        var table = $('<table />');
        for (var i = 0; i < stationInfo.StationLines.length; i++) {
            var stationLine = stationInfo.StationLines[i];
            var tr = $('<tr/>');

            var td1 = $('<td/>');            
            var span = $('<span class="lineId" />').text(stationLine.LineInfo.LineId).css('background-color', stationLine.LineInfo.LineColor).appendTo(td1)
            if(stationLine.LineInfo.LineId == '3')
                span.css('color', 'black');
            td1.appendTo(tr);

            var td2 = $('<td/>')
            $('<span/>').text(stationLine.LineInfo.LineRoute.ToStationName).appendTo(td2);
            td2.appendTo(tr);

            var td3 = $('<td/>');
            $('<span/>').text(stationLine.StartEndTime.StartTime).appendTo(td3);
            $('<span/>').text('-').appendTo(td3);
            $('<span/>').text(stationLine.StartEndTime.EndTime).appendTo(td3);
            td3.appendTo(tr);

            tr.appendTo(table);
        }
        table.appendTo(this.stationInfoContainer);

        // Start button content
        if (isSetStartButton) {
            this.setStartButton.children('.SetStartContent').text('取消设为起点');
        } else {
            this.setStartButton.children('.SetStartContent').text('设为起点');
        }

        // End button content
        if (isSetEndButton) {
            this.setEndButton.children('.SetEndContent').text('取消设为终点');
        } else {
            this.setEndButton.children('.SetEndContent').text('设为终点');
        }

        // shown on correct position
        this.rightPanel.css('left', x);
        this.rightPanel.css('top', y);
        this.rightPanel.show();
    }

    RightPanelUpdator.prototype.hide = function () {
        this.rightPanel.hide();
    }
}