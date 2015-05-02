<%@ Page Title="" Language="C#" MasterPageFile="~/MASTER/Main1.Master" AutoEventWireup="true" CodeBehind="dwjlActUpdateList.aspx.cs" Inherits="STLHWEB.SLWL.DWJL.dwjlActUpdateList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <title>对外交流活动更新</title>
 <link href="/CSS/publicStyle.css" type="text/css" rel="Stylesheet" />
 <link href="/CSS/stjsStyle.css" type="text/css" rel="Stylesheet" />
    <link href="/CSS/slwlStyle.css" type="text/css" rel="Stylesheet" />
<style type="text/css">
 input[type=text]{
    width: 150px;
    height: 14px;
    margin-left:4px;
    margin-right:4px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="ContentPlaceHolder4" runat="server">
  <div><h2 class="title">对外交流活动更新</h2><hr /></div>
  <div> 
    <table border="0" cellspacing="0" cellpadding="0" width="100%" style="text-align:center; vertical-align:middle;">
    	<tr>
    		<td style="text-align:right; vertical-align:middle;">交流活动名称<input type="text" id="txtbox_activityName4" runat="server" /></td>
            <td style="text-align:center; vertical-align:middle;">发起方<input type="text" id="txtbox_sponsor4" runat="server"  /></td>
            <td style="text-align:left; vertical-align:middle;">受邀方<input type="text" id="txtbox_invitee4" runat="server"  /></td>
            <td style="text-align:left; vertical-align:middle;"><input type="submit" id="btn_query" value="查询" runat="server" onserverclick="btn_query_onclick" /></td>
    	</tr>
    </table>
 </div>
 <div> <table  style="width:878px; border:1px double #479ac7;"><tr style="border:1px double #9be8cc;"><td>
     <asp:GridView ID="gvw_dwjlQuerry" runat="server" AllowSorting="True" 
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
         OnSorting="gvw_dwjlQuerry_Sorting" 
         style="text-align:center; vertical-align:middle;" PageSize="50" DataKeyNames="sljlDate"
         onpageindexchanged="gvw_dwjlQuerry_PageIndexChanged" 
         onpageindexchanging="gvw_dwjlQuerry_PageIndexChanging" 
         onrowdatabound="gvw_dwjlQuerry_RowDataBound">
         <AlternatingRowStyle BackColor="White" />
         <Columns>
                
             <%-- 年月日--%>
  <asp:BoundField HeaderText="序号" >
              <ItemStyle HorizontalAlign="Center" />
              <HeaderStyle HorizontalAlign="Center" Width="5%" />
          </asp:BoundField>
                  <asp:BoundField DataField="sljlId" HeaderText="sljlId" Visible="False" />
             <asp:BoundField DataField="sljlName" HeaderText="交流活动名称" ReadOnly="true" 
                 SortExpression="sljlName" />
             <asp:BoundField DataField="inviter" HeaderText="发起方" ReadOnly="true" 
                 SortExpression="inviter" />
             <asp:BoundField DataField="invited" HeaderText="受邀方" ReadOnly="true" 
                 SortExpression="invited"/>
             <asp:BoundField DataField="sljlDate" HeaderText="交流活动日期" ReadOnly="true" 
                 SortExpression="sljlDate" />
             <asp:BoundField DataField="status" HeaderText="状态" ReadOnly="true" 
                 SortExpression="status"  />
               <asp:HyperLinkField HeaderText="详细信息" DataNavigateUrlFields="sljlId" 
                 DataNavigateUrlFormatString="/SLWL/DWJL/dwjlfillin/dwjlActFillIn.aspx?ID={0}" Text="详细信息">
             <ControlStyle Font-Underline="True" ForeColor="#FF6600" />
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
      
      <div><br />
             <asp:Button ID="add" runat="server" Text="添加" onclick="add_Click"/><br /><br /></div>
 </div>
</asp:Content>
