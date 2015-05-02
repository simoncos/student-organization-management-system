<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="perCenterSidebar.ascx.cs"
    Inherits="STLHWEB.USERCTRL.perCenterSidebar" %>
 <ul class="nav">   
<asp:Repeater ID="LeftMenu" runat="server" OnItemDataBound="LeftMenu_ItemDataBound">
    <ItemTemplate>
    <li onclick="hide('M_<%# Eval("ModuleID")%>')"><a href="javascript:void(0)"><span></span>&nbsp;&nbsp;<%# Eval("M_CName")%></a> </li>
    <li id="M_<%# Eval("ModuleID")%>" style="display: none" >
        <ul class="nav1">
            <asp:Repeater ID="LeftMenu_Sub" runat="server">
                <ItemTemplate>
                        <li><a name="nav1a" href="<%# Eval("M_Directory")%>">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%# Eval("M_CName")%></a> </li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </li>
    </ItemTemplate>
</asp:Repeater>
 </ul>


