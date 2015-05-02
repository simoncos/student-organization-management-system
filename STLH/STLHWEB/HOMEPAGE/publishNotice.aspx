<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="publishNotice.aspx.cs" Inherits="STLHWEB.HOMEPAGE.publishNotice" ValidateRequest = false %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>发布消息</title>
   <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
 <style type="text/css">
 .Watermark{color:#bebebe;}
.Validator{background-color:#f5f7fb;}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
<script type="text/javascript" language="javascript" src="/JS/ckeditor/ckeditor.js"></script>
   <div> <h2 class="title">发布消息</h2></div> 
    <div><table  style="width:876px; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
    
    <table id="type" border="0" cellspacing="0" cellpadding="0" width="876px">
    	   <tr><td class="text">&nbsp;&nbsp;标题</td>
           	  <td class="textBox">
              <asp:TextBox ID="title" CssClass="box" runat="server" style="width:350px;" maxlength="20" ></asp:TextBox></td></tr>
            <tr><td class="text">&nbsp;&nbsp;接收方</td>
              <td class="textBox">
                  <asp:RadioButton ID="rb_Type0" runat="server" Text="系统消息" GroupName="1" onclick="typeonclick()"/>
                  <asp:RadioButton ID="rb_Type3" runat="server" Text="全网消息" GroupName="1" onclick="typeonclick()"/>
                  <asp:RadioButton ID="rb_Type1" runat="server" Text="部分角色可见" GroupName="1" onclick="type1onclick()"/>
                  <asp:RadioButton ID="rb_Type2" runat="server" Text="全部角色可见" GroupName="1" onclick="typeonclick()"/>
                  <asp:RadioButton ID="rb_Type4" runat="server" Text="部分个人可见" GroupName="1" onclick="type4onclick()"/>
              </td></tr>
               <tr id="type1" style="display:none;"><td class="text">&nbsp;&nbsp;请选择角色</td>
           	  <td class="textBox">
                     <asp:CheckBoxList ID="CheckBoxList1" runat="server" 
                         DataSourceID="SqlDataSource1" DataTextField="R_RoleName" 
                         DataValueField="RoleID" RepeatDirection="Horizontal">
                     </asp:CheckBoxList>
                     <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
                         ConnectionString="Data Source=YAOMINGDAN-PC\YMDSQLSERVER;Initial Catalog=STLHDB;Persist Security Info=True;User ID=sa" 
                         ProviderName="System.Data.SqlClient" 
                         SelectCommand="SELECT [R_RoleName], [RoleID] FROM [sys_Roles]">
                     </asp:SqlDataSource>
              </td></tr>
              <tr id="type4" style="display:none;"><td class="text">&nbsp;&nbsp;请输入个人姓名</td>
           	  <td class="textBox">
              <asp:TextBox ID="tx_receiveId" CssClass="box" runat="server" style="width:350px;" maxlength="20" ></asp:TextBox></td></tr>
    </table>
    <div style="width:876px;">
    
    <textarea id="tahtml"  name="tahtml" runat="Server" class="textfield" style="width:876px;Height:212px;"></textarea>
    <script type="text/javascript">
        CKEDITOR.replace('<%=tahtml.ClientID %>');
    </script>
    </div>

    </td>
    </tr>
    </table>
    
    </div>
    <br />
    <div>
           <asp:Button ID="putIn" runat="server" Text="发布" CssClass="btn" onclick="putIn_Click" 
                  /> <br /><br /></div><%--提示框--%>

                    <script type="text/javascript" language="javascript">

//                        mainLoop = function () {
//                            if ($("#rb_Type4:checked").val()==true) {
//                       
//                            var url = "personalCenter.ashx?param=type1";
//                            $.post(url, function (data) {
//                                $("#type").html(data);
//                            });                       
//                            }
//                           return true; 
//                        }
//                       mainLoop();
                        
                        function type4onclick() {
                            $("#type1").css({ display: "none" });
                            $("#type4").css({ display: "" });

                        }
                        function type1onclick() {
                            $("#type4").css({ display: "none" });
                            $("#type1").css({ display: "" });

                        }
                        function typeonclick() {
                            $("#type4").css({ display: "none" });
                            $("#type1").css({ display: "none" });

                        }


                    </script>
</asp:Content>
