function CalculateToolTipUpdator(toolTip) {
    this.toolTip = toolTip;
    this.calculateButton = toolTip.find('.calculate');
    this.calculatingSpan = toolTip.find('.calculating');
    this.calculatedSpan = toolTip.find('.calculated');

    CalculateToolTipUpdator.prototype.show = function (left) {
        this.left = left;
        this.toolTip.css('left', left);
        this.toolTip.show();
    }

    CalculateToolTipUpdator.prototype.fadeIn = function (callFunction, callee) {
        this.toolTip.animate({
            left: this.left - this.toolTip.outerWidth()
        }, 500, function () {
            if (callFunction != null)
                callFunction.call(callee);
        });
    }

    CalculateToolTipUpdator.prototype.fadeOut = function (callFunction, callee) {
        this.toolTip.animate({
            left: this.left
        }, 500, function () {
            if (callFunction != null)
                callFunction.call(callee);
        });
    }

    CalculateToolTipUpdator.prototype.showCalculateButton = function () {
        this.calculateButton.show();
    }

    CalculateToolTipUpdator.prototype.hideCalculateButton = function () {
        this.calculateButton.hide();
    }

    CalculateToolTipUpdator.prototype.showCalculatingSpan = function () {
        this.calculatingSpan.show();
    }

    CalculateToolTipUpdator.prototype.hideCalculatingSpan = function () {
        this.calculatingSpan.hide();
    }

    CalculateToolTipUpdator.prototype.showCalculatedSpan = function () {
        this.calculatedSpan.show();
    }

    CalculateToolTipUpdator.prototype.hideCalculatedSpan = function () {
        this.calculatedSpan.hide();
    }
}