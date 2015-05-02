<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="mainMenu.ascx.cs" Inherits="STLHWEB.USERCTRL.mainMenu" %>
<link rel="stylesheet" href="/CSS/publicStyle.css"/>
<script type="text/javascript" src="/SCRIPT/JScript1.js"></script>
<table class="sidebar_bg" cellspacing="0">
    <tr><td>
    <table border="0" cellspacing="0" cellpadding="0" class="sidebar_bg">
        <tr style="height: 50px; width: 200px;" class="sidebar_menu_title"><th>学生信息</th></tr>
        <tr style="height:60px;"><td>
            <table style="width: 200px"><tr><td align="center"><a href="/LOGIN/login.aspx" target="_blank">登录</a></td></tr>
            <tr><td align="center">
                <asp:Label ID="lab_userName" runat="server" Height="19px" Width="190px" cellspacing="0" cellpadding="0"></asp:Label></td></tr>
                   <tr><td align="center">
                       <asp:Label ID="lab_userNum" runat="server" Height="19px" Width="190px" cellspacing="0" cellpadding="0"></asp:Label></td></tr>
            </table>
            </td>
        </tr>
    </table>
    </td></tr>

    <tr><td></td></tr>

    <tr><td>
    <table width="200px" border="0" cellspacing="0" cellpadding="0" class="sidebar_bg">
    <tr style="height:29px;" class="sidebar_menu_title" onclick="hide('hindMenuFunc0')"><th>
        <a href="#">社团成立</a></th></tr>
        <tr id="hindMenuFunc0"><td>
            <table width="200px">
                   <tr><td align="center"><a href="/STJS/STCL/stclApply.aspx">成立申请</a></td></tr>
                   <tr><td align="center"><a href="/STJS/STCL/stclExamList.aspx" target="_blank">待审核列表</a></td></tr>
                   <tr><td align="center"><a href="/STJS/STCL/stclQuery.aspx">申请结果</a></td></tr>

            </table>
            </td>
        </tr>
    </table>
    </td></tr>

    <tr><td></td></tr>
    
     <tr><td>
     <table width="200px" border="0" cellspacing="0" cellpadding="0" class="sidebar_bg">
     <tr style="height:29px;" class="sidebar_menu_title" onclick="hide('hindMenuFunc2')"><th><a href="#">社团资料管理</a></th></tr>
        <tr id="hindMenuFunc2"><td>
            <table width="200px">
                   <tr><td align="center"><a href="/STJS/STZL/stzlQueryList.aspx">社团资料查询</a></td></tr>
                   <tr><td align="center"><a href="/STJS/STZL/stzlUpdateList.aspx">社团资料更新</a></td></tr>
            </table>
            </td>
        </tr>
    </table>
    </td></tr>

    <tr><td></td></tr>

     <tr><td>
     <table width="200px" border="0" cellspacing="0" cellpadding="0" class="sidebar_bg">
     <tr style="height:29px;" class="sidebar_menu_title" onclick="hide('hindMenuFunc3')"><th><a href="#">赞助管理</a></th></tr>
        <tr id="hindMenuFunc3"><td>
            <table width="200px">
                   <tr><td align="center"><a href="/SLWL/ZZGL/zzglActQueryList.aspx">赞助活动列表</a></td></tr>
                   <tr><td align="center"><a href="/SLWL/ZZGL/zzglActExamineList.aspx">赞助活动审核列表</a></td></tr>
                   <tr><td align="center"><a href="/SLWL/ZZGL/zzglSponsorList.aspx">赞助商信息</a></td></tr>
            </table>
            </td>
        </tr>
    </table>
    </td></tr>

    <tr><td></td></tr>

     <tr><td>
     <table width="200px" border="0" cellspacing="0" cellpadding="0" class="sidebar_bg">
     <tr style="height:29px;" class="sidebar_menu_title" onclick="hide('hindMenuFunc4')"><th><a href="#">对外交流</a></th></tr>
        <tr id="hindMenuFunc4"><td>
            <table width="200px">
                   <tr><td align="center"><a href="/SLWL/DWJL/dwjlActQueryList.aspx">交流活动列表</a></td></tr>
                   <tr><td align="center"><a href="/SLWL/DWJL/dwjlActFillIn.aspx">交流活动登记</a></td></tr>
                   <tr><td align="center"><a href="/SLWL/DWJL/dwjlActExamineList.aspx">活动审核列表</a></td></tr>
                   <tr><td align="center"><a href="/SLWL/DWJL/dwjlActQuery.aspx">活动查询列表</a></td></tr>
            </table>
            </td>
        </tr>
    </table>
     </td></tr>

</table>