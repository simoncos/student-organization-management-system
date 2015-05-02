(function () {
    var $backToTopTxt = "",
	$backToTopEle = $('<div id="backToTop" class="backToTop"></div>').appendTo($("body"))
        .text($backToTopTxt).attr("title", "点火发射").click(function () {
            //大比例火箭
            Id("backToTop").style.height = "147px";
            Id("backToTop").style.width = "60px";
            Id("backToTop").style.backgroundImage = "url(huojian1.png)"
            //小比例火箭
            //            Id("backToTop").style.height = "74px";
            //            Id("backToTop").style.width = "30px";
            //            Id("backToTop").style.backgroundImage = "url(huojian1small.png)";
            $("#backToTop").css({ backgroundImage: "url('/MASTER/perCenterM/huojian1small.png')", width: "30px", height: "74px" });
            $("html, body").animate({ scrollTop: 0 }, 500);
            $("#backToTop").animate({ bottom: 700 }, 400);

        }), $backToTopFun = function () {
            var st = $(document).scrollTop();
            var winh = $(window).height();
            if (st > 0) {
                $backToTopEle.show();


            } else {
                //大比例火箭
                Id("backToTop").style.height = "119px";
                Id("backToTop").style.width = "60px";
                Id("backToTop").style.backgroundImage = "url(huojian.png)"
                //小比例火箭

                //                Id("backToTop").style.height = "60px";
                //                Id("backToTop").style.width = "30px";
                //                Id("backToTop").style.backgroundImage = "url(huojiansmall.png)"
                $("#backToTop").css({ backgroundImage: "url(/MASTER/perCenterM/huojiansmall.png)", width: "30px", height: "60px" });
                $backToTopEle.visible = false;
                $backToTopEle.css({ bottom: "100px" });
                $backToTopEle.hide();
            }
            //IE6下的定位
            if (!window.XMLHttpRequest) {
                $backToTopEle.css("top", st + winh - 166);
            }
        };
    $(window).bind("scroll", $backToTopFun);
    $(function () { $backToTopFun(); });
})();
//获取元素
function Id(_sId) {
    return document.getElementById(_sId);
}
