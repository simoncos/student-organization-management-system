/**************************************************
*利用css和js代码实现换肤功能
*header
*sidebar
*footer
*rightmodule
*moduletitle
*  统一用background-color 换相应颜色
header footer rightmodule sidebar 再加上图片url
**************************************************/

function classname(clsName) {
    return document.getElementsByClassName(clsName);
}
function showskin() {
    // document.documentElement.scrollTop = 0;
    // changeskinposition();
    skinpanel.style.display = "";
    //hide('skinpanel');
}
function hideskin() {
    skinpanel.style.display = "none";
}
function changeskinposition() {
    var skinpanel = document.getElementById("skinpanel");
    var setting = document.getElementById("setting");
    skinpanel.style.top = setting.offsetTop + "px";
    skinpanel.style.left = setting.offsetLeft - 114 + "px";
}
function changeskin(_sId) {
    var color = document.getElementById(_sId).style.backgroundColor;
    Id("header").style.backgroundColor = color;
    Id("sidebar").style.backgroundColor = color;
    Id("footer").style.backgroundColor = color;
    Id("rightmodule").style.backgroundColor = color;
    Id("sitemap").style.borderBottom = "2px  solid " + color;
    var color = document.getElementById(_sId).style.backgroundColor;
    var path1 = "/MASTER/perCenterM/" + _sId + "/" + "header.png";
    var path2 = "/MASTER/perCenterM/" + _sId + "/" + "sidebar.png";
    for (i = 0; i < classname("moduletitle").length; i++) {
        classname("moduletitle")[i].style.backgroundColor = color;
    }
    $(".titlet").css("background-color",color);
    Id("header").style.backgroundImage = "url('" + path1 + "')";
    Id("sidebar").style.backgroundImage = "url('" + path2 + "')";

}