// JavaScript Document
/* �ýű���Ȩ����netleague�Ŷ� ����ӭ��������*/
/*

�õ����Ƿ������Ҫ���������ط� �޸�ʱ��ע�⣬���ڸ�ע����˵��,�У�55��94,145��

*/
//����ʱ�¼�
var nowurlnode;
var scrollheight;
//var scrollheight1;
var scrollheightTip=1;
var contentstatustip = 0;
var str_url;
str_url = window.location.href;
window.onload = function ()
{
    sidebarnavheight();
    if (document.documentElement.clientWidth < 1110) {
        Id('container').style.width = 1110 + "px";
        Id('center').style.width = 1110 + "px";
        Id('header').style.width = 1110 + "px";
        Id('rightmodule').style.display = "none";
    }
    else {
        Id('container').style.width = "100%";
        Id('center').style.width = "100%";
        Id('header').style.width = "100%";
        Id('rightmodule').style.display = "";
        var rightmodulewidth = document.documentElement.clientWidth - 1109;
        Id('rightmodule').style.width = rightmodulewidth+10 + "px";
    }

    
    var navgroup = document.getElementsByName('nav1a');
    for (i = 0; i < navgroup.length; i++) {
        if (str_url==navgroup[i].href.toString()) {
            navgroup[i].style.backgroundImage = "url(/MASTER/perCenterM/nav22.png)";
            navgroup[i].parentNode.parentNode.parentNode.style.display = "";
            nowurlnode=navgroup[i].parentNode.parentNode.parentNode;
        }
        else{
            
        }
    }


}
//������ı䴰�ڴ�Сʱʹ��ʽ���ֲ���
window.onresize = function () {
    if (document.documentElement.clientWidth < 1110) {
        Id('container').style.width = 1110 + "px";
        Id('center').style.width = 1110 + "px";
        Id('header').style.width = 1110 + "px";
        Id('rightmodule').style.display = "none";
    }
    else {
        Id('container').style.width = "100%";
        Id('center').style.width = "100%";
        Id('header').style.width = "100%";
        Id('rightmodule').style.display = "";
        var rightmodulewidth = document.documentElement.clientWidth - 1109;
        Id('rightmodule').style.width = rightmodulewidth+10 + "px";
    }
    
}
window.onscroll = function ()
{
    sidebarnavheight();
    var scrolltop = document.documentElement.scrollTop==0 ? document.body.scrollTop:document.documentElement.scrollTop;
    if(scrolltop>60)
    {
        //��Ҫ��ֹͷ������ �����²���ע��
        Id('sidebar').style.top = "40px";
        Id('header').style.top = "-60px";
		Id('headertitlePic').style.backgroundImage="url()";
    }
    else {
        Id('sidebar').style.top = "100px";
        Id('header').style.top = "0px";
        Id('headertitlePic').style.backgroundImage = "url(/MASTER/perCenterM/title1.png)";
		
    }
    
}


//����������̶�
function unabsolute()
{
    
   
    if(scrollheightTip==0)
    {
        Id('header').style.position = "static";
        Id('sidebar').style.position = "static";
        Id('center').style.marginTop = "0px";
        Id('content').style.marginLeft = "0px";
        document.documentElement.scrollLeft = 0;

        scrollheight = document.documentElement.scrollTop;
        document.documentElement.scrollTop = 0;
    }
    scrollheightTip = 1;
}
//ʹ�������̶�
function inabsolute ()
{
    
    
    if (scrollheightTip == 1) {
        //��Ҫ��ֹͷ������ �����²���ע�ͻָ�
        // Id('header').style.top = "0px";
        // Id('sidebar').style.top = "100px";
        //**************************************

        Id('header').style.position = "fixed";
        Id('header').style.zIndex = 500;
        
        Id('sidebar').style.position = "fixed";
        Id('sidebar').style.zIndex = 500;
        Id('center').style.marginTop = "100px";
        Id('content').style.marginLeft = "210px";
        // scrollheight1 = document.documentElement.scrollTop;
         // document.documentElement.scrollTop = scrollheight;
        }
        
        scrollheightTip = 0;
        
}
sameheight();
function sameheight() {
    //ʹ��������������ҳ�ײ�����ˮƽ
    if (Id('sidebar').offsetHeight < Id('content').offsetHeight) {
        Id('sidebar').style.minHeight = Id('content').offsetHeight + "px";
        Id('rightmodule').style.minHeight = Id('content').offsetHeight + "px";

    }
    else {
        Id('content').style.minHeight = Id('sidebar').offsetHeight - 10 + "px";
        Id('rightmodule').style.minHeight = Id('content').offsetHeight + "px";
    }
}
//��ȡԪ��
function Id(_sId) {
    return document.getElementById(_sId);
}
//������������
function hide(_sId) {

//        var navgroup = document.getElementsByClassName('nav1');
//        for (i = 0; i < navgroup.length; i++) {

//            if (navgroup[i].parentNode.style.display == "" && navgroup[i].parentNode != Id(_sId) && navgroup[i].parentNode!=nowurlnode) {
//               navgroup[i].parentNode.style.display = "none";
//           }
//        }
    Id(_sId).style.display = Id(_sId).style.display == "none" ? "" : "none";
	/* if(Id(_sId).style.display=="none")
	{
			$("#"+_sId).slideDown(100);
	}
	else{
		$("#"+_sId).slideUp(100);
	} */
    sameheight();
    sidebarnavheight();
    var rightmodulewidth = document.documentElement.clientWidth - 1109;
    Id('rightmodule').style.width = rightmodulewidth + 10 + "px";
    
}
function sidebarnavheight() {
    //todo: ��Ҫ��ֹͷ������ ��60��-1
    var scrolltop = document.documentElement.scrollTop==0 ? document.body.scrollTop:document.documentElement.scrollTop;
    if (scrolltop > 60 && Id('sidebarnav').clientHeight < document.documentElement.clientHeight - 150) {
        inabsolute();
    }
    else {
        if(contentstatustip==0)
        {
            unabsolute();
        }
        else
        {
			if(scrolltop<=60)
            unabsolute();
			else
			inabsolute();
        }
        
    }
}
function contentstatus()
{
	
    contentstatustip = 0;
    sidebarnavheight();
}
function contentstatusout()
{
    contentstatustip = 1;
    sidebarnavheight();
}

//$("#content").mouseover(function(){
//  contentstatusout();
//});
//$("#sidebar").mouseover(function(){
//  contentstatus();
//});



