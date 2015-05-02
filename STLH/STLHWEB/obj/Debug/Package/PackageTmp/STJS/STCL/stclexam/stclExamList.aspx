<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="stclExamList.aspx.cs" Inherits="STLHWEB.STJS.STCL.stclExamList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>待审核社团申请</title>
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
 <link href="/CSS/slwlStyle.css" type="text/css" rel="Stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
<div><h2 class="title">待审核社团列表</h2></div>
 

 <div><table  style="width:878px; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
   
     <asp:GridView ID="gvw_stclExamList" runat="server" CellPadding="4" ForeColor="#333333" 
         GridLines="None" AllowSorting="True"
         style="text-align:center; vertical-align:middle;" PageSize="50"
         AutoGenerateColumns="False"
         Width="100%"
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
          
          onsorting="gvw_stclExamList_Sorting" 
         onpageindexchanged="gvw_stclExamList_PageIndexChanged" 
         onpageindexchanging="gvw_stclExamList_PageIndexChanging" 
         onrowdatabound="gvw_stclExamList_RowDataBound" DataKeyNames="presidentId" 
        >
         <AlternatingRowStyle BackColor="White" />
         <Columns>
          <asp:BoundField HeaderText="序号" ReadOnly="true" >
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
             <asp:BoundField DataField="presidentId" HeaderText="presidentId" Visible="False" />
             <asp:BoundField HeaderText="社团名称" DataField="stName" ReadOnly="true" 
                 SortExpression="stName" />
             <asp:BoundField HeaderText="会长姓名"  DataField="stuName" ReadOnly="true" 
                 SortExpression="stuName"/>
                 <asp:BoundField HeaderText="联系方式"  DataField="stuTel" ReadOnly="true" 
                 SortExpression="stuTel"/>
             <asp:BoundField HeaderText="提交时间" DataField="applyDate" ReadOnly="true" 
                 SortExpression="applyDate" />
             <asp:HyperLinkField HeaderText="审核" DataNavigateUrlFields="presidentId" 
                 DataNavigateUrlFormatString="stclExam.aspx?ID={0}" 
                 Text="审核" Target="_blank" >
             <ControlStyle Font-Overline="False" Font-Underline="True" ForeColor="#FF6600" />
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
     </asp:GridView></td></tr></table>
 </div>
</asp:Content>
