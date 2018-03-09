
    var firstload = true;
    function resize() {
        var headerHeight = $("header.fixed-top").outerHeight();
        var footerHeight = $("footer.fixed-bottom").outerHeight();
        $("div.body-content").css("margin-top", headerHeight);
        $("div.side-nav").css("margin-top", headerHeight);
        $("div.body-content").css("margin-bottom", footerHeight);
        var bodyheight = $(window).innerHeight();
        $(".body-content").css("height", bodyheight);
        $("iframe").css("height", (bodyheight *.8)+"px");
    }

    resize();
    $(window).resize(resize);
