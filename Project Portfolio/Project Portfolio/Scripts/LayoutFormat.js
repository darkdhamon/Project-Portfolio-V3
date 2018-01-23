
    var firstload = true;
    function resize() {
        var headerHeight = $("header.navbar").outerHeight();
        $("div.body-content").css("margin-top", headerHeight);
        var bodyheight = $(window).innerHeight();
        $("iframe").css("height", (bodyheight *.8)+"px");
    }

    resize();
    $(window).resize(resize);
