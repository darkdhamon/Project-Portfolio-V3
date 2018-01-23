
    var firstload = true;
    function resize() {
        var headerHeight = $("header.navbar").outerHeight();
        $("div.body-content").css("margin-top", headerHeight);
        var footerheight = $("footer").outerHeight();
        var bodyheight = $(window).innerHeight();
        $("iframe").css("height", (bodyheight *.8)+"px");
    }

    resize();
    $(window).resize(resize);
