var metroPainter;
var defaultController;

$(document).ready(function () {

    metroPainter = new MetroPainter($('#metroCanvas'), $(".canvasContainer"));
    defaultController = new DefaultController(metroPainter);

    // scroll
    $('#metroCanvas').bind('mousewheel', function (e) {
        defaultController.onScroll(e);
    });

    // initialize canvas
    defaultController.initializeCanvas();
})

// resize
$(window).resize(function (e) {
    defaultController.onResize(e);
});