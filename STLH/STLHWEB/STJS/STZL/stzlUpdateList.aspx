<%@ Page Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="stzlUpdateList.aspx.cs" Inherits="STLHWEB.STJS.STZL.stzlUpdateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>社团信息管理</title>
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
    <link href="/CSS/slwlStyle.css" type="text/css" rel="Stylesheet" />
<style type="text/css">
 input[type=text]{
    width: 140px;
    height: 14px;
    margin-left:4px;
    margin-right:4px;
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
  <div><h2 class="title">社团信息管理</h2><hr /></div>
  
 <div> 
     <asp:GridView ID="gvw_stzlUpdateList" runat="server" AllowSorting="True" 
         AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" 
         GridLines="None"  Width="98%"  
                                    HeaderStyle-CssClass="table_title"
                                    CssClass = "table-box"
                                    HeaderStyle-HorizontalAlign="Center"    
                                    cellspacing="1"
                                    BorderWidth="0px"
                                    BackColor="White"
                                    RowStyle-HorizontalAlign="Center"     
                                    RowStyle-Height="28px"
                                    RowStyle-CssClass="row" 
                                    AlternatingRowStyle-CssClass="row1" 
        onsorting="gvw_stzlUpdateList_Sorting"
         style="text-align:center; vertical-align:middle;" PageSize="50" >
         <AlternatingRowStyle BackColor="White" />
         <Columns>
         <asp:BoundField HeaderText="序号" >
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
           <asp:BoundField DataField="stId" HeaderText="stId" Visible="False" />
            <asp:BoundField DataField="stName" HeaderText="社团名称" ReadOnly="true" 
                 SortExpression="stName" />
            <asp:BoundField DataField="stType" HeaderText="社团类别" ReadOnly="true" 
                 SortExpression="stType" />
            <asp:BoundField DataField="presidentName" HeaderText="会长姓名" ReadOnly="true" 
                 SortExpression="presidentName"  />
            <asp:HyperLinkField HeaderText="修改信息" DataNavigateUrlFields="stId" 
                 DataNavigateUrlFormatString="test.aspx?ID={0}" Text="修改" Target="_blank">
             <ItemStyle ForeColor="#00CC00" />
             </asp:HyperLinkField>
             
         </Columns>
         <EditRowStyle BackColor="#2461BF" />
         <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
         <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
         <RowStyle BackColor="#EFF3FB" />
         <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
         <SortedAscendingCellStyle BackColor="#F5F7FB" />
         <SortedAscendingHeaderStyle BackColor="#6D95E1" />
         <SortedDescendingCellStyle BackColor="#E9EBEF" />
         <SortedDescendingHeaderStyle BackColor="#4870BE" />
     </asp:GridView>
     </div>
</asp:Content>