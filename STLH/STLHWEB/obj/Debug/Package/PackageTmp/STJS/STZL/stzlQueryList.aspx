<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="stzlQueryList.aspx.cs" Inherits="STLHWEB.STJS.STZL.stzlQueryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>社团资料查询</title>
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
 <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">

<div><h2 class="title">社团资料查询</h2><hr /><br/></div>

 <div>
   
     <asp:GridView ID="gvw_stzlQueryList" runat="server" CellPadding="4" ForeColor="#333333" 
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
         onsorting="gvw_stzlQueryList_Sorting" 
         onpageindexchanged="gvw_stzlQueryList_PageIndexChanged" 
         onpageindexchanging="gvw_stzlQueryList_PageIndexChanging" 
         onrowdatabound="gvw_stzlQueryList_RowDataBound">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
          <asp:BoundField HeaderText="序号" >
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
             <asp:BoundField HeaderText="社团名称" DataField="stName" ReadOnly="true" 
                 SortExpression="stName" />
             <asp:BoundField HeaderText="社团类别"  DataField="stType" ReadOnly="true" 
                 SortExpression="stType"/>
             <asp:BoundField HeaderText="社团星级"  DataField="star" ReadOnly="true" 
                 SortExpression="star"/>
             <asp:BoundField HeaderText="会费" DataField="fee" ReadOnly="true" 
                 SortExpression="fee" />
             <asp:BoundField HeaderText="会长姓名"  DataField="presidentName" ReadOnly="true" 
                 SortExpression="presidentName"/>
             <asp:BoundField HeaderText="会长电话" DataField="stuTel" ReadOnly="true" 
                 SortExpression="stuTel" />
             <asp:BoundField HeaderText="会长邮箱" DataField="stuEmail" ReadOnly="true" 
                 SortExpression="stuEmail" />
             <asp:BoundField HeaderText="会长QQ号" DataField="stuQQ" ReadOnly="true" 
                 SortExpression="stuQQ" />
    
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
