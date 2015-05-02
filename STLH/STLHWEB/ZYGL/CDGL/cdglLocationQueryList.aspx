<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="cdglLocationQueryList.aspx.cs" Inherits="STLHWEB.ZYGL.CDGL.cdglLocationQueryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>场地资料查询</title>
 <link href="/CSS/cdglStyle.css" type="text/css" rel="Stylesheet" />
 <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
<div><h2 class="title">场地资料查询</h2><hr /><br/></div>

 <div>
   
     <asp:GridView ID="gvw_cdglQueryList" runat="server" CellPadding="4" ForeColor="#333333" 
         GridLines="None" AllowSorting="True"
         style="text-align:center; vertical-align:middle;" PageSize="50"
         AutoGenerateColumns="False"
         Width="98%"
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
         onsorting="gvw_cdglQueryList_Sorting" 
         onpageindexchanged="gvw_cdglQueryList_PageIndexChanged" 
         onpageindexchanging="gvw_cdglQueryList_PageIndexChanging" 
         onrowdatabound="gvw_cdglQueryList_RowDataBound">
         <AlternatingRowStyle BackColor="White" />
          <Columns>
          <asp:BoundField HeaderText="序号" >
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
             <asp:BoundField HeaderText="场地名称" DataField="location" ReadOnly="true" 
                 SortExpression="location" />
             <asp:BoundField HeaderText="可借时段"  DataField="allowedTimeRange" ReadOnly="true" 
                 SortExpression="allowedTimeRange"/>


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