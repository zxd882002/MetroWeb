function ContextPanelUpdator(contextPanel) {
    this.contextPanel = contextPanel;
    this.stationInfoHeaderStationName = contextPanel.find(".stationInfo > .stationInfoHeader > .stationName");
    this.stationInfoContainer = contextPanel.find(".stationInfo > .stationInfoContainer");
    this.setStartButton = contextPanel.find(".startEndSet > .setStart");
    this.setEndButton = contextPanel.find(".startEndSet > .setEnd");
    this.canvasRight = 0;
    this.canvasBotton = 0;

    ContextPanelUpdator.prototype.show = function (stationInfo, isSetStartButton, isSetEndButton, x, y) {
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
            this.setStartButton.children('.setStartContent').text('取消设为起点');
        } else {
            this.setStartButton.children('.setStartContent').text('设为起点');
        }

        // End button content
        if (isSetEndButton) {
            this.setEndButton.children('.setEndContent').text('取消设为终点');
        } else {
            this.setEndButton.children('.setEndContent').text('设为终点');
        }

        // shown on correct position
        var width = this.contextPanel.outerWidth();
        var height = this.contextPanel.outerHeight();

        if(x + width > this.canvasRight)
            x -= width;

        if(y + height > this.canvasBotton)
            y -= height;

        this.contextPanel.css('left', x);
        this.contextPanel.css('top', y);
        this.contextPanel.show();
    }

    ContextPanelUpdator.prototype.hide = function () {
        this.contextPanel.hide();
    }
}