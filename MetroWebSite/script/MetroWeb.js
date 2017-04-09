var defaultController;

$(document).ready(function () {
    defaultController = new DefaultController($('#metroCanvas'), $(".canvasContainer"),$('.header'), $('.footer'));

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