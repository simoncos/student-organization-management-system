<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="cdglLocationList.aspx.cs" Inherits="STLHWEB.ZYGL.CDGL.cdglLocationList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>场地信息记录表</title>
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
    <link href="/CSS/slwlStyle.css" type="text/css" rel="Stylesheet" />
    <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />

 <style type="text/css">
input[type=text]{
    width: 60px;
    }
 .table_titleOwn {
    FONT:thin 12px Tahoma, Verdana;	
    COLOR: #ffffff;	
    BACKGROUND-COLOR: #804D61;
    HEIGHT: 30px;
    PADDING-LEFT: 5px;
    PADDING-RIGHT:5px;
}
 </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
 <div><h2 class="title">场地信息记录表</h2><hr /></div> 
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>  
        <div><br />
                <table id="tableData" style="width:100%; border:1px double #479ac7;" >
                <tr style="border:1px double #9be8cc; text-align:center; vertical-align:middle;">
                <td  style=" text-align:center; vertical-align:middle;"><%--border:1px  solid #9be8cc;--%>
                    <table style="width:100%;  text-align:center; vertical-align:middle;">
                    <tr><td>场地名称：<asp:TextBox ID="txtbox_location" runat="server" style="width:250px;"></asp:TextBox></td>
                    <td>可借时段：<asp:TextBox ID="txtbox_allowedTimeRange"  style="width:250px;" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                    <td>
                        <asp:button ID="btn_putIn" Text="提交" runat="server" onclick="btn_putIn_Click"/>&nbsp;&nbsp;
                        <asp:button id="btn_clear" text="清除" runat="server" onclick="btn_clear_Click"/></td></tr>
                    </table><%--border:1px double #479ac7;--%>
                </td>
                </tr>  
                </table>
        </div> 
    </ContentTemplate>
    <Triggers>
         <asp:AsyncPostBackTrigger    ControlID="btn_clear" />
    </Triggers>
</asp:UpdatePanel>

<div><p><br /></p>
<asp:UpdatePanel ID="UpdatePanel2" runat="server">
    <ContentTemplate>  
<table  style="width:100%; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
    <asp:GridView ID="gvw_cdglLocationList" runat="server"  AutoGenerateColumns="False" 
        CellPadding="4"  ForeColor="#333333" 
         style="text-align:center; vertical-align:middle;" PageSize="50" Width="100%"
          HeaderStyle-CssClass="table_title"
                                    CssClass = "table-box"
                                    HeaderStyle-HorizontalAlign="Center"    
                                    cellspacing="1"
                                    BorderWidth="0px"
                                    BackColor="White"
                                    RowStyle-HorizontalAlign="Center"     
                                    RowStyle-Height="28px"
                                    RowStyle-CssClass="row" 
                                    AlternatingRowStyle-CssClass="row1"  DataKeyNames="location"
        GridLines="None"  AllowSorting="True" AllowPaging="True" 
        onpageindexchanged="gvw_cdglLocationList_PageIndexChanged" 
        onpageindexchanging="gvw_cdglLocationList_PageIndexChanging" 
        onrowdatabound="gvw_cdglLocationList_RowDataBound" 
        onsorting="gvw_cdglLocationList_Sorting" 
        onrowdeleting="gvw_cdglLocationList_RowDeleting" >
        <AlternatingRowStyle BackColor="White" />
        <Columns><asp:BoundField HeaderText="序号" ReadOnly="true" >
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
            <asp:BoundField DataField="location" HeaderText="场地名称"  
                SortExpression="location" >
            <HeaderStyle/>
            </asp:BoundField>
            <asp:BoundField DataField="allowedTimeRange" HeaderText="可借时段"  
                SortExpression="allowedTimeRange" >
            <HeaderStyle/>
<%--            <asp:BoundField DataField="fillName" HeaderText="填写人姓名" HeaderStyle-Width="50px"
                SortExpression="fillName" />--%>
                </asp:BoundField>
            <asp:BoundField DataField="fillDate" HeaderText="填写时间" 
                SortExpression="fillDate" >
            <HeaderStyle />
            </asp:BoundField>
            <asp:CommandField HeaderText="删除" 
                HeaderStyle-Width="70px" EditText="删除" ShowDeleteButton="True" >
            <ControlStyle Font-Underline="True" ForeColor="#FF6600" Font-Overline="False" />
            </asp:CommandField>
        </Columns>
        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White"  HorizontalAlign="Center"/>
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />
    </asp:GridView></td></tr></table>

        </ContentTemplate>
        <Triggers>
         <asp:AsyncPostBackTrigger   ControlID="btn_putIn" />
        </Triggers>
        </asp:UpdatePanel> 
        </div>
</asp:Content>