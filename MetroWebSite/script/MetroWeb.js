var defaultController;

$(document).ready(function () {
    defaultController = new DefaultController(
        $('#metroCanvas'), 
        $(".canvasContainer"),
        $('.header'), 
        $('.footer'), 
        $(".rightPannel"));

    // scroll
    $('#metroCanvas').bind('mousewheel', function (e) {
        defaultController.onScroll(e);
    });

    // set start button
    $('.SetStart').on('click', function(){
        defaultController.onClickSetStartButton();
    });

    // set end button
    $('.SetEnd').on('click', function(){
        defaultController.onclickSetEndButton();
    });

    // clear set button
    $('.ClearSet').on('click', function(){
        defaultController.onClickClearSetButton();
    });

    // calculate button
    $('.Calculate').on('click', function(){
        defaultController.onClickCalculatorButton();
    });

    // close right pannel button
    $('.closeButton').on('click', function(){
        defaultController.rightPanelUpdator.hide();
    })

    // initialize canvas
    defaultController.initializeCanvas();
})

// resize
$(window).resize(function (e) {
    defaultController.onResize(e);
});