function alertWin(title, msg, w, h) {
    var titleheight = "22px"; // 窗口标题高度
  
    var color = "#FFFFFF"; // 窗口的标题颜色
    var bgcolor = "#000000"; // 窗口的标题背景色
    var iWidth = document.documentElement.clientWidth;
    var iHeight = document.documentElement.clientHeight;
    var bgObj = document.createElement("div");
    bgObj.style.cssText = "position:absolute;left:0px;top:0px;width:" + iWidth + "px;height:" + Math.max(document.body.clientHeight, iHeight) + "px;filter:Alpha(Opacity=30);opacity:0.3;background-color:#000000;z-index:101;";
    document.body.appendChild(bgObj);
    var msgObj = document.createElement("div");
    msgObj.style.cssText = "position:absolute;font:11px '宋体';top:" + 2*(iHeight - h)  + "px;left:" + (iWidth - w) / 2 + "px;width:" + w + "px;height:" + h + "px;text-align:center;border:0px solid " + bgcolor + ";background-color:" + bgcolor + ";padding:0px;line-height:22px;z-index:102;";
    document.body.appendChild(msgObj);

    var table = document.createElement("table");
    msgObj.appendChild(table);
    table.style.cssText = "margin:0px;border:0px;padding:0px;";
    table.cellSpacing = 0;
    var tr = table.insertRow(-1);
    var titleBar = tr.insertCell(-1);
    titleBar.style.cssText = "width:100%;height:" + titleheight + "px;text-align:left;padding:3px;margin:0px;font:bold 13px '宋体';color:" + color + ";border-bottom:1px solid " + color + ";cursor:move;background-color:" + bgcolor;
    titleBar.style.paddingLeft = "10px";
    titleBar.innerHTML = title;
    var moveX = 0;
    var moveY = 0;
    var moveTop = 0;
    var moveLeft = 0;
    var moveable = false;
    var docMouseMoveEvent = document.onmousemove;
    var docMouseUpEvent = document.onmouseup;
    titleBar.onmousedown = function () {
        var evt = getEvent();
        moveable = true;
        moveX = evt.clientX;
        moveY = evt.clientY;
        moveTop = parseInt(msgObj.style.top);
        moveLeft = parseInt(msgObj.style.left);

        document.onmousemove = function () {
            if (moveable) {
                var evt = getEvent();
                var x = moveLeft + evt.clientX - moveX;
                var y = moveTop + evt.clientY - moveY;
                if (x > 0 && (x + w < iWidth) && y > 0 && (y + h < iHeight)) {
                    msgObj.style.left = x + "px";
                    msgObj.style.top = y + "px";
                }
            }
        };
        document.onmouseup = function () {
            if (moveable) {
                document.onmousemove = docMouseMoveEvent;
                document.onmouseup = docMouseUpEvent;
                moveable = false;
                moveX = 0;
                moveY = 0;
                moveTop = 0;
                moveLeft = 0;
            }
        };
    }

    var closeBtn = tr.insertCell(-1);
    closeBtn.style.cssText = "cursor:pointer; padding:2px;background-color:" + bgcolor;
    closeBtn.innerHTML = "<span style='font-size:15pt; color:" +color + ";'>×</span>";
    closeBtn.onclick = function () {
        document.body.removeChild(bgObj);
        document.body.removeChild(msgObj);
    }
    var msgBox = table.insertRow(-1).insertCell(-1);
    msgBox.style.cssText = "font:12px '宋体';color:#fff;padding:18px 23px;background-color:#000000;background-image:url('/IMAGE/ajax-loader_dark.gif') no-repeat;";
    msgBox.colSpan = 2;
    msgBox.innerHTML = msg;

    function getEvent() {
        return window.event || arguments.callee.caller.arguments[0];
    }
}
    