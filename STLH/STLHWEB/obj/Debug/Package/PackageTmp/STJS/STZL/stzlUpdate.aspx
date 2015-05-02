<%@ Page Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="stzlUpdate.aspx.cs" Inherits="STLHWEB.STJS.STZL.stzlUpdate" %>

<%@ Register src="../../USERCTRL/mainMenu.ascx" tagname="mainMenu" tagprefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>社团信息管理</title>
<link href="../../CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

  <div> <h2 class="title"><a name="top">社团信息管理</a></h2></div>
        
        <div>
        	<table class="contentTable" style="background-color:#eeeeee;">

            <tr><td class="text">&nbsp;&nbsp;社团名称</td>
           	  <td class="textBox"><asp:TextBox ID="stName" CssClass="box" runat="server"></asp:TextBox>&nbsp;&nbsp;
                     <asp:RequiredFieldValidator ID="stName_checkTip" runat="server" 
                         ErrorMessage="请输入社团名!" ControlToValidate="stName" ForeColor="Red" 
                         SetFocusOnError="True"></asp:RequiredFieldValidator></td></tr>

            <tr><td class="text">&nbsp;&nbsp;社团类别</td>
           	  <td class="textBox"><asp:DropDownList ID="stType" CssClass="ddl" runat="server" >
                  <asp:ListItem>其他</asp:ListItem>
                  <asp:ListItem>文艺</asp:ListItem>
                  <asp:ListItem>体育</asp:ListItem>
                  <asp:ListItem>公益</asp:ListItem>
                  <asp:ListItem>就业</asp:ListItem>
                  <asp:ListItem>学习</asp:ListItem>
                  </asp:DropDownList></td></tr>

                <tr><td class="text">&nbsp;&nbsp;社团星级</td>
           	    <td class="textBox"><asp:TextBox ID="star" CssClass="box" runat="server"></asp:TextBox>
                </td></tr>

                <tr><td class="text">&nbsp;&nbsp;十佳称号</td>
           	    <td class="textBox"><asp:TextBox ID="topTen" CssClass="box" runat="server"></asp:TextBox>
                </td></tr>

                <tr><td class="text">&nbsp;&nbsp;会费</td>
           	  <td class="textBox"><asp:TextBox ID="fee" CssClass="box" runat="server">0</asp:TextBox>
                </td></tr>

                <tr><td class="text">&nbsp;&nbsp;会长学号</td>
           	  <td class="textBox"><asp:TextBox ID="stuId" CssClass="box" 
                      runat="server" ReadOnly="True" onkeydown="if(event.keyCode==8)return false;" /></td></tr>

                <tr><td class="text">&nbsp;&nbsp;会长姓名</td>
           	    <td class="textBox"><asp:TextBox ID="stuName" CssClass="box" 
                      runat="server" ReadOnly="True" onkeydown="if(event.keyCode==8)return false;" /></td></tr>

              <tr><td class="text">&nbsp;&nbsp;电话</td>
           	  <td class="textBox"><asp:TextBox ID="stuTel" CssClass="box" 
                      runat="server" ReadOnly="True" onkeydown="if(event.keyCode==8)return false;" /></td></tr>

                <tr><td class="text">&nbsp;&nbsp;邮箱</td>
           	    <td class="textBox"><asp:TextBox ID="stuEmail" CssClass="box" 
                      runat="server" ReadOnly="True" onkeydown="if(event.keyCode==8)return false;" /></td></tr>

                <tr><td class="text">&nbsp;&nbsp;宿舍</td>
           	    <td class="textBox"><asp:TextBox ID="stuDormitory" CssClass="box" 
                      runat="server" ReadOnly="True" onkeydown="if(event.keyCode==8)return false;" /></td></tr>
     
                <tr><td class="text">&nbsp;&nbsp;指导教师</td>
           	    <td class="textBox"><asp:TextBox ID="guideTeacher" CssClass="box" runat="server" placeholder="未定"></asp:TextBox>
                </td></tr>

                <tr><td class="text">&nbsp;&nbsp;挂靠单位</td>
           	    <td class="textBox"><asp:TextBox ID="guideUnit" CssClass="box" runat="server" placeholder="未定"></asp:TextBox>
                </td></tr>
            </table>
        </div>

         <div><br/><hr /><br />
             <asp:Button ID="save" runat="server" Text="保存" onserverclick="save_Click" 
                 CssClass="btn" onclick="save_Click"/>&nbsp;&nbsp;&nbsp;
           <asp:Button ID="cancel" runat="server" Text="取消" CssClass="btn" 
                 onserverclick="cancel_Click" onclick="cancel_Click" /> <br /><br /></div>
</asp:Content>