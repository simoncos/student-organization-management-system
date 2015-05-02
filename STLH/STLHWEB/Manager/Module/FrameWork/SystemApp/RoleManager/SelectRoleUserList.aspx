﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/MasterPage/PageTemplate.Master" AutoEventWireup="true" 
 Inherits="FrameWork.web.Module.FrameWork.UserManager.Default"
 %>
<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <link rel="stylesheet" type="text/css" href="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/css/subModal.css" />

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/common.js"></script>

    <script type="text/javascript" src="<%=Page.ResolveUrl("~/") %>Manager/inc/FineMessBox/js/subModal.js"></script>

    <FrameWorkWebControls:HeadMenuWebControls ID="HeadMenuWebControls1" runat="server"
        ButtonList-Capacity="4" HeadOPTxt="用户资料列表" HeadTitleTxt="用户资料列表" HeadHelpTxt="选中要增加的用户名前的checkbox框，点击增加按钮增加到角色。">
    </FrameWorkWebControls:HeadMenuWebControls>
    <FrameWorkWebControls:TabOptionWebControls ID="TabOptionWebControls1" runat="server">
        <FrameWorkWebControls:TabOptionItem  ID="TabOptionItem1" runat="server" Tab_Name="用户资料列表">
            <asp:GridView ID="GridView1" runat="server" OnSorting="GridView1_Sorting" OnRowCreated="GridView1_RowCreated">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            &nbsp;<input id="UserIDX" type="checkbox" value="<%#Eval("UserID") %>" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:BoundField SortExpression="U_UserNO" HeaderText="员工编号" DataField="U_UserNO" />
                    <asp:BoundField SortExpression="U_LoginName" HeaderText="用户名" DataField="U_LoginName" />    
                    <asp:BoundField SortExpression="U_CName" HeaderText="中文名" DataField="U_CName" />
                    <asp:TemplateField SortExpression="U_GroupID" HeaderText="部门">
                        <ItemTemplate>
                            <%#Get_U_GroupID((int)Eval("U_GroupID")) %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField SortExpression="U_WorkStartDate" HeaderText="到职日期" DataField="U_WorkStartDate" DataFormatString="{0:yyyy/MM/dd}"
                        HtmlEncode="false" />
                    <asp:TemplateField SortExpression="U_Type" HeaderText="用户类型">
                        <ItemTemplate>
                            <%#FrameWork.BusinessFacade.sys_UserType((int)Eval("U_Type"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField SortExpression="U_Status" HeaderText="用户状态">
                        <ItemTemplate>
                            <%#GetStat((int)Eval("U_Status"))%>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <FrameWorkWebControls:AspNetPager ID="AspNetPager1" runat="server" OnPageChanged="AspNetPager1_PageChanged">
            </FrameWorkWebControls:AspNetPager>
            <input id='CheckboxAll' value='0' type='checkbox' onclick='javascript:SelectAll();'/>选择全部 <input type="button" class="button_bak" onclick="javascript:addtorole();" value="增加用户"/>
        </FrameWorkWebControls:TabOptionItem>
        <FrameWorkWebControls:TabOptionItem ID="TabOptionItem2" runat="server" Tab_Name="查询">
            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                <tr>
                    <td class="table_body table_body_NoWidth">
                        用户名</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="U_LoginName" runat="server" CssClass="text_input"></asp:TextBox></td>
                    <td class="table_body table_body_NoWidth">
                        部门</td>
                    <td class="table_none table_none_NoWidth">
                        <input type="hidden" runat="server" name="U_GroupID" id="U_GroupID" value=""><input
                            runat="server" name="U_GroupID_Txt" id="U_GroupID_Txt" size="15" value="" class="text_input"
                            readonly>
                        <input type="button" value="选择部门" id="button3" name="buttonselect" onclick="javascript:ShowDepartID()"
                            class="cbutton">
                        <input type="button" value="清除" onclick="javascript:ClearSelect();" class="cbutton" />
                    </td>
                </tr>
                <tr>
                    <td class="table_body table_body_NoWidth">
                        中文名</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="U_CName" runat="server" CssClass="text_input"></asp:TextBox></td>
                    <td class="table_body table_body_NoWidth">
                        员工编号</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:TextBox ID="U_UserNO" runat="server" CssClass="text_input"></asp:TextBox></td>
                </tr>
                <tr>
                    <td class="table_body table_body_NoWidth">
                        用户类型</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="U_Type" runat="server">
                            <asp:ListItem Value="">不限</asp:ListItem>
                            <asp:ListItem Value="1">普通用户</asp:ListItem>
                            <asp:ListItem Value="2">管理员</asp:ListItem>
                            <asp:ListItem Value="0">超级用户</asp:ListItem>
                        </asp:DropDownList></td>
                    <td class="table_body table_body_NoWidth">
                        用户状态</td>
                    <td class="table_none table_none_NoWidth">
                        <asp:DropDownList ID="U_Status" runat="server">
                            <asp:ListItem Value="">不限</asp:ListItem>
                            <asp:ListItem Value="0">正常</asp:ListItem>
                            <asp:ListItem Value="1">禁止</asp:ListItem>
                        </asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="4" align="right">
                        <asp:Button ID="Button1" runat="server" CssClass="button_bak" Text="查询" OnClick="Button1_Click" /></td>
                </tr>
            </table>
        </FrameWorkWebControls:TabOptionItem>
    </FrameWorkWebControls:TabOptionWebControls>

    <script language="javascript">
        rnd.today=new Date(); 

    rnd.seed=rnd.today.getTime(); 

    function rnd() { 

　　　　rnd.seed = (rnd.seed*9301+49297) % 233280; 

　　　　return rnd.seed/(233280.0); 

    }; 

    function rand(number) { 

　　　　return Math.ceil(rnd()*number); 

    }; 
    
function AlertMessageBox(file_name)
    {

       	        if (file_name!=undefined){
	            var ShValues = file_name.split('||');
	            if (ShValues[1]!=0)
	            {
	                document.all.<%=U_GroupID_Txt_ID %>.value=ShValues[0];
	                document.all.<%=U_GroupID_ID %>.value=ShValues[1];
	            }
	        }
	         
    }
      function ShowDepartID()
        {
            showPopWin('选择部门','SelectGroup.aspx?'+rand(10000000), 215, 255, AlertMessageBox,true,true)
        }
        function ClearSelect()
        {
   	        document.all.<%=U_GroupID_Txt_ID %>.value="";
            document.all.<%=U_GroupID_ID %>.value="";
        }
    </script>
    
    
    <script language="javascript" type="text/javascript">
<!--

        function SelectAll() {
            var e = document.getElementsByTagName("input");
            var IsTrue;
            if (document.getElementById("CheckboxAll").value == "0") {
                IsTrue = true;
                document.getElementById("CheckboxAll").value = "1"
            }
            else {
                IsTrue = false;
                document.getElementById("CheckboxAll").value = "0"
            }
            for (var i = 0; i < e.length; i++) {
                if (e[i].type == "checkbox") {
                    e[i].checked = IsTrue;
                }
            }
        }
        function addtorole() {
            var useridxs = "";
            var checkok = false;
            var e = document.getElementsByTagName("input");
            for (var i = 0; i < e.length; i++) {
                if (e[i].type == "checkbox") {
                    if (e[i].checked == true && e[i].id == "UserIDX") {
                        checkok = true;
                        useridxs = useridxs+ ","+ e[i].value;
                        //break;
                    }
                }
            }
            if (checkok) {
                if (confirm('你确定要增加选中用户为当前角色吗？')) {
                    //alert(useridxs);
                    window.returnVal = useridxs;
                    window.parent.hidePopWin(true);
                }
                else {
                    checkok = false;
                }
            }
            else {

                alert("请选择要增加的用户!");
                return false;
            }
        }
// -->
    </script>
</asp:Content>
