
    var firstload = true;
    function resize() {
        var headerHeight = $("header.navbar").outerHeight();
        $("div.body-content").css("margin-top", headerHeight);
    }

    resize();
    $(window).resize(resize);
