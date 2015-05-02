<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" 
CodeBehind="zzglActQueryList.aspx.cs" Inherits="STLHWEB.SLWL.ZZGL.zzglActQueryList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>赞助活动信息查询</title>
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
<link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
<style type="text/css">
    input[type=text]{
    width: 200px;
    height: 17px;
    margin-left:2px;
    margin-right:2px;
    }
 </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
<div><h2 class="title">赞助活动信息查询</h2><hr /></div>
 
 <div style="height:35px; vertical-align:middle;" > 
    <table border="0" cellspacing="0" cellpadding="0" width="878px" style="text-align:center; vertical-align:middle;">
    	<tr style="height:25px;">
    		<td style="text-align:center; vertical-align:middle;">赞助商名称
            <input type="text" id="txtbox_zzActName" runat="server"/>
            <input type="submit" id="btn_query" value="查询" runat="server" onserverclick="btn_query_onclick"/></td>

    	</tr>
    </table>
 </div >
 <div>
   <table  style="width:878px; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
     <asp:GridView ID="gvw_zzglQuery" runat="server" CellPadding="4" ForeColor="#333333" 
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
          onsorting="gvw_zzglQuery_Sorting" 
         onpageindexchanged="gvw_zzglQuery_PageIndexChanged" 
         onpageindexchanging="gvw_zzglQuery_PageIndexChanging" 
         onrowdatabound="gvw_zzglQuery_RowDataBound">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
          <asp:BoundField HeaderText="序号" >
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
             <asp:BoundField HeaderText="slzzId" DataField="slzzId" Visible="False" />
             <asp:BoundField HeaderText="赞助商名称" DataField="sponsorName" ReadOnly="true" 
                 SortExpression="sponsorName" />
             <asp:BoundField HeaderText="赞助形式"  DataField="sponsorType" ReadOnly="true" 
                 SortExpression="sponsorType"/>
                 <asp:BoundField HeaderText="预约时间段"  DataField="reserTimeRange" ReadOnly="true" 
                 SortExpression="reserTimeRange"/>
             <asp:BoundField HeaderText="外联负责人" DataField="responsName" ReadOnly="true" 
                 SortExpression="responsName" />
             <asp:BoundField HeaderText="状态"  DataField="status" ReadOnly="true" 
                 SortExpression="status"/>
             <asp:BoundField HeaderText="修改时间" DataField="fillDate" ReadOnly="true" 
                 SortExpression="fillDate" />
               

     <%--   权限问题     <asp:TemplateField>
              <ItemTemplate>
                   <%#Eval("u_userLoginInfo.权限").ToString() == "actor" ? "" : " <asp:HyperLinkField HeaderText='详细信息' DataNavigateUrlFields='slzzId' DataNavigateUrlFormatString='zzglActDetailQueryA.aspx?ID={0}'  Target='_blank' Text='详细信息' />"%>
              </ItemTemplate>
            </asp:TemplateField>--%>
             <asp:HyperLinkField HeaderText="详细信息" DataNavigateUrlFields="slzzId" 
                 DataNavigateUrlFormatString="zzglActDetailQueryA.aspx?ID={0}"  Target="_blank" 
                 Text="详细信息" />
         
         
    
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
