var defaultController;

$(document).ready(function () {
    defaultController = new DefaultController(
        $('#metroCanvas'), 
        $('.canvasContainer'),
        $('.header'), 
        $('.footer'), 
        $('.contextPannel'),
        $('.calculateToolTip'));

    // scroll
    $('#metroCanvas').bind('mousewheel', function (e) {
        defaultController.onScroll(e);
    });

    // set start button
    $('.setStart').on('click', function(){
        defaultController.onClickSetStartButton();
    });

    // set end button
    $('.setEnd').on('click', function(){
        defaultController.onclickSetEndButton();
    });

    // calculate button
    $('.calculate').on('click', function(){
        defaultController.onClickCalculatorButton();
    });

    // close context pannel button
    $('.closeButton').on('click', function(){
        defaultController.contextPanelUpdator.hide();
    })

    // initialize canvas
    defaultController.initializeCanvas();
})

// resize
$(window).resize(function (e) {
    defaultController.onResize(e);
});