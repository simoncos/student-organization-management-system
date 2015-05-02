<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="dwjlActExamineList.aspx.cs" Inherits="STLHWEB.SLWL.DWJL.dwjlActExamineList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>待审核交流活动</title>
 <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
 <link href="/CSS/slwlStyle.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
  <div><h2 class="title">待审核交流活动</h2></div>
  <div> <table  style="width:878px; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
     <asp:GridView ID="gvw_dwjlActExamineList" runat="server" AllowSorting="True" 
         AutoGenerateColumns="False"  CellPadding="4" ForeColor="#333333" 
         GridLines="None"  Width="100%"  
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
         OnSorting="gvw_dwjlActExamineList_Sorting" 
         style="text-align:center; vertical-align:middle;" PageSize="50" DataKeyNames="sljlDate"
         onpageindexchanged="gvw_dwjlActExamineList_PageIndexChanged" 
         onpageindexchanging="gvw_dwjlActExamineList_PageIndexChanging" 
         onrowdatabound="gvw_dwjlActExamineList_RowDataBound">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
                
             <%-- 年月日--%>
  <asp:BoundField HeaderText="序号" >
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
                
             <asp:BoundField  DataField="sljlId" HeaderText="sljlId" Visible="False" />
                
             <asp:BoundField DataField="sljlName" HeaderText="交流活动名称" ReadOnly="true" 
                 SortExpression="sljlName" />
             <asp:BoundField DataField="inviter" HeaderText="发起方" ReadOnly="true" 
                 SortExpression="inviter" />
             <asp:BoundField DataField="invited" HeaderText="受邀方" ReadOnly="true" 
                 SortExpression="invited"/>
             <asp:BoundField DataField="sljlDate" HeaderText="交流活动日期" ReadOnly="true" 
                 SortExpression="sljlDate" />
             <asp:BoundField DataField="responsName" HeaderText="校内负责人" ReadOnly="true" 
                 SortExpression="responsName"  />
             <asp:HyperLinkField HeaderText="审核" DataNavigateUrlFields="sljlId" 
                 DataNavigateUrlFormatString="dwjlActExamine.aspx?ID={0}" Text="审核">
             <ControlStyle Font-Underline="True" ForeColor="#FF6600" />
             </asp:HyperLinkField>
             <%--跳转到dwjlActExamine--%>
             
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
     </asp:GridView></td></tr></table>
 </div>
</asp:Content>
